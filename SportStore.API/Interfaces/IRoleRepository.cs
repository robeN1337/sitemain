using SportStore.API.Entities;

namespace SportStore.API.Interfaces
{
    public interface IRoleRepository
    {
        Role CreateRole(Role role);
        Role UpdateRole(Role role, Guid guid);
        bool DeleteRole(Guid guid);
        List<Role> GetRoles();

        Role GetRoleById(Guid guid);
    }
}
