using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserHub.Context;
using UserHub.Dto;
using UserHub.Entities;

namespace UserHub.Services
{
    public class AuthService(IConfiguration configuration, MyDbContext dbContext) : IAuthService
    {
        public ApiResponse Login(UserLoginDto userLogin)
        {
            var userFound = dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(user => user.Email == userLogin.Email) ?? throw new UnauthorizedAccessException("Credenciales inválidas");
            if (!userFound.Password.Equals(userLogin.Password))
            {
                return new ApiResponse { Status = 401, Data = "Credenciales inválidas" }; // Fix for CS0029
            }

            userFound.LastSessionDate = DateTime.Now;

            dbContext.Users.Entry(userFound).Property(u => u.LastSessionDate).IsModified = true;
            dbContext.SaveChanges();

            var token = GenerateJwtToken(userFound);

            return new ApiResponse { Status=200, Data=new AuthDto { AccessToken = token } };
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                    {
                        new(JwtRegisteredClaimNames.Sub, user.IdNumber ?? string.Empty),
                        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new("email", user.Email ?? string.Empty),
                        new("names",user.Names ?? string.Empty),
                        new("surnames",user.Surnames ?? string.Empty),
                        new(ClaimTypes.Role, user.Role.Name ?? string.Empty)
                    };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpirationInMinutes"]!)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
