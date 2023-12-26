using Doctors.Models;
using Doctors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Doctors.Controllers
{
    [ApiController]
    [Route("api/permissions")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public IActionResult GetPermissions()
        {
            var permissions = _permissionService.GetPermissions();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public IActionResult GetPermissionById(int id)
        {
            var permission = _permissionService.GetPermissionById(id);
            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }

        [HttpPost]
        public IActionResult AddPermission([FromBody] Permission permission)
        {
            _permissionService.AddPermission(permission);
            return CreatedAtAction(nameof(GetPermissionById), new { id = permission.PermissionId }, permission);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePermission(int id, [FromBody] Permission updatedPermission)
        {
            var permission = _permissionService.GetPermissionById(id);
            if (permission == null)
            {
                return NotFound();
            }

            _permissionService.UpdatePermission(updatedPermission);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePermission(int id)
        {
            var permission = _permissionService.GetPermissionById(id);
            if (permission == null)
            {
                return NotFound();
            }

            _permissionService.DeletePermission(id);
            return NoContent();
        }
    }

}
