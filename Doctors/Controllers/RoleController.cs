using Doctors.Models;
using Doctors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleService.GetRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost]
        public IActionResult AddRole([FromBody] Role role)
        {
            _roleService.AddRole(role);
            return CreatedAtAction(nameof(GetRoleById), new { id = role.RoleId }, role);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, [FromBody] Role updatedRole)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }

            _roleService.UpdateRole(updatedRole);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }

            _roleService.DeleteRole(id);
            return NoContent();
        }
    }

}
