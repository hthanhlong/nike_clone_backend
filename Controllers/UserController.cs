using Microsoft.AspNetCore.Mvc;
using nike_clone_backend.Models.DTOs;
using Nike_clone_Backend.Services;

namespace Nike_clone_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            return Ok(await _userService.GetUser(id));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            await _userService.UpdateUser(id, updateUserDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
    }
}

