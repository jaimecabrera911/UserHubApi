using Microsoft.AspNetCore.Mvc;
using UserHub.Dto;
using UserHub.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<FindUserDto> Get()
        {
            return userService.GetUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{idNumber}")]
        public FindUserDto Get(string idNumber)
        {
            return userService.GetUser(idNumber);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto user)
        {
            userService.CreateUser(user);
            
            return CreatedAtAction(nameof(Post), new { id = user.IdNumber});
        }

        // PUT api/<UserController>/5
        [HttpPut("{idNumber}")]
        public void Put(string idNumber, [FromBody] CreateUserDto user)
        {
            userService.UpdateUser(idNumber, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{idNumber}")]
        public void Delete(string idNumber)
        {
            userService.DeleteUser(idNumber);
        }
    }
}
