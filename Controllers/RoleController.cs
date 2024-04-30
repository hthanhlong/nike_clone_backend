using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Reformation.Models;
using Reformation.Services.RoleService;

namespace Reformation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RoleController : ControllerBase
    {
        private IValidator<RoleModel> _validator;
        private readonly IRoleService _roleService;
        public RoleController(IValidator<RoleModel> validator, IRoleService roleService)
        {
            _validator = validator;
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetRole(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] RoleModel role)
        {
            try
            {
                var result = await _validator.ValidateAsync(role);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }
                await _roleService.AddRole(role);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            return Ok();
        }
    }
}

