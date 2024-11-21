using Microsoft.AspNetCore.Mvc;
using SportStore.API.Entities;
using SportStore.API.Interfaces;

namespace SportStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _rolerep;

        public RoleController(IRoleRepository roleRepository)
        {
            _rolerep = roleRepository;
        }

        [HttpGet]
        public ActionResult GetRoles()
        {
            return Ok(_rolerep.GetRoles());
        }

        [HttpGet("{guid}")]

        public ActionResult GetRoleById(Guid guid)
        {
            return Ok(_rolerep.GetRoleById(guid));
        }

        [HttpPost]

        public ActionResult PostRole(Role role)
        {
            return Ok(_rolerep.CreateRole(role));
        }

        [HttpDelete("{guid}")]

        public ActionResult DeleteRole(Guid guid)
        {
            return Ok(_rolerep.DeleteRole(guid));
        }

        [HttpPut("{guid}")]

        public ActionResult UpdateRole(Role role, Guid guid) 
        {
            return Ok(_rolerep.UpdateRole(role, guid));
        }
    }
}
