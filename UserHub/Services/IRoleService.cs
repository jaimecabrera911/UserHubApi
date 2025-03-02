using UserHub.Dto;

namespace UserHub.Services
{
    public interface IRoleService
    {

        public IEnumerable<RoleDto> GetRoles();

        public RoleDto GetRoleById(int roleId);

        public RoleDto GetRoleByName(string roleName);

        public void CreateRole(RoleDto role);

        public void UpdateRole(string name, RoleDto role);

        public void DeleteRole(string name);


    }
}
