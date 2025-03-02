using AutoMapper;
using UserHub.Context;
using UserHub.Dto;
using UserHub.Entities;

namespace UserHub.Services
{
    public class RoleService(MyDbContext dbContext, IMapper mapper) : IRoleService
    {

        public void CreateRole(RoleDto role)
        {
            dbContext.Roles.Add(mapper.Map<Role>(role));
            dbContext.SaveChanges();
        }

        public void DeleteRole(string idName)
        {
            var role = dbContext.Roles.FirstOrDefault(role => role.Name == idName)?? throw new Exception("Role not found");
            dbContext.Roles.Remove(role);
            dbContext.SaveChanges();
        }

        public RoleDto GetRoleById(int roleId)
        {
            var roleFound = dbContext.Roles.FirstOrDefault(role => role.Id == roleId) ?? throw new Exception("Role not found");
            return mapper.Map<RoleDto>(roleFound);
        }

        public RoleDto GetRoleByName(string roleName)
        {
            var roleFound = dbContext.Roles.FirstOrDefault(role => role.Name == roleName) ?? throw new Exception("Role not found"); ;
            return mapper.Map<RoleDto>(roleFound);
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            var roles = dbContext.Roles.ToList();
            return mapper.Map<RoleDto[]>(roles);
        }

        public void UpdateRole(string name, RoleDto role)
        {
            var roleFound = dbContext.Roles.FirstOrDefault(r => r.Name == name) ?? throw new Exception("Role not found");
            roleFound.Name = role.Name;
            dbContext.Roles.Update(roleFound);
            dbContext.SaveChanges();
        }
    }
}
