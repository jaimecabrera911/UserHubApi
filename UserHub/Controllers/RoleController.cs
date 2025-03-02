using Microsoft.AspNetCore.Mvc;
using UserHub.Dto;
using UserHub.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(IRoleService roleService ) : ControllerBase
    {

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<RoleDto> Get()
        {
            return roleService.GetRoles();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{idName}")]
        public RoleDto Get(string idName)
        {
            return roleService.GetRoleByName(idName);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public CreatedAtActionResult Post([FromBody]RoleDto role)
        {
            return CreatedAtAction(nameof(Post), new { id = role.Name });
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(string name, [FromBody]RoleDto role)
        {
            roleService.UpdateRole(name, role);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(string name)
        {
            roleService.DeleteRole(name);
        }
    }
}
