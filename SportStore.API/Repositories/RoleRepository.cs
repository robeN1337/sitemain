using SportStore.API.Entities;
using SportStore.API.Interfaces;

namespace SportStore.API.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public IList<Role> Roles { get; set; } = new List<Role>();
        public Role CreateRole(Role role)
        {
            role.guid = Guid.NewGuid();
            Roles.Add(role);
            return role;
        }

        public bool DeleteRole(Guid guid)
        {
            var result = GetRoleById(guid);
            Roles.Remove(result);
            return true;

        }

        public List<Role> GetRoles()
        {
            return (List<Role>)Roles;
        }

        public Role UpdateRole(Role role, Guid guid)
        {
            var result = GetRoleById(guid);
            result.NameOfRole = role.NameOfRole;
            result.Description = role.Description;
            return result;
        }

        public Role GetRoleById(Guid guid)
        {
            var result = Roles.Where(r => r.guid == guid).FirstOrDefault();
            if (result == null)
            {
                throw new Exception($"Нет роли с id = {guid}");
            }
            return result;
        }
    }
}
