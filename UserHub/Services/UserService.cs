using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserHub.Context;
using UserHub.Dto;
using UserHub.Entities;

namespace UserHub.Services;

public class UserService(MyDbContext dbContext, IMapper mapper) : IUserService
{
    public IEnumerable<FindUserDto> GetUsers()
    {
        var usersFound = dbContext.Users
            .Include(user => user.Role)
            .ToList();
        return mapper.Map<List<FindUserDto>>(usersFound);
    }

    public FindUserDto GetUser(string idNumber)
    {
        var user = dbContext.Users
            .Include(user => user.Role)
            .FirstOrDefault(user => user.IdNumber == idNumber)?? throw new Exception("User not found");
        return mapper.Map<FindUserDto>(user);
    }


    public FindUserDto GetUserByEmail(string email)
    {
        var user = dbContext.Users
            .Include(user => user.Role)
            .FirstOrDefault(user => user.Email == email) ?? throw new Exception("User not found");
        return mapper.Map<FindUserDto>(user);
    }

    public void CreateUser(CreateUserDto user)
    {
        var roleFound = dbContext.Roles.First(role => role.Name == user.Role);
        var userEntity = mapper.Map<User>(user);
        userEntity.Role = roleFound;
        userEntity.LastSessionDate = DateTime.Now ;

        dbContext.Users.Add(userEntity);

        dbContext.SaveChanges();
    }

    public CreateUserDto UpdateUser(string idNumber, CreateUserDto userUpdate)
    {
        var roleFound = dbContext.Roles.FirstOrDefault(role => role.Name == userUpdate.Role) ?? throw new Exception("El rol especificado no existe.");
        var userEntity = dbContext.Users.FirstOrDefault(user => user.IdNumber == idNumber) ?? throw new Exception("El usuario no existe.");
        mapper.Map(userUpdate, userEntity);

        userEntity.RoleId = roleFound.Id;

        dbContext.SaveChanges();

        return userUpdate;
    }

    public void DeleteUser(string idNumber)
    {
        var user = dbContext.Users.First(user => user.IdNumber == idNumber) ?? throw new Exception("El usuario no existe.");
        dbContext.Users.Remove(user);

        dbContext.SaveChanges();
    }
}