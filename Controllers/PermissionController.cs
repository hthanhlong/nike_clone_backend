using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reformation.Models;
using Reformation.Services.RoleService;

namespace Reformation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PermissionController : ControllerBase
    {
        private IValidator<PermissionModel> _validator;
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService, IValidator<PermissionModel> validator)
        {
            _permissionService = permissionService;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult GetPermissions()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetPermission(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPermission(PermissionModel permission)
        {
            try
            {
                var result = await _validator.ValidateAsync(permission);
                if (!result.IsValid)
                {
                    var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                    return BadRequest(errors);
                }
                var newPermission = await _permissionService.AddPermission(permission);
                return Ok(newPermission);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{id}")]
        public IActionResult UpdatePermission(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePermission(int id)
        {
            return Ok();
        }
    }
}

