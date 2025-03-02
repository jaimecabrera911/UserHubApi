using Microsoft.AspNetCore.Mvc;
using UserHub.Dto;
using UserHub.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {

        // POST api/login
        [HttpPost("login")]
        public ApiResponse Login([FromBody]UserLoginDto user)
        {
            return authService.Login(user);
        }
    }
}
