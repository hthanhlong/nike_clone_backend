using Microsoft.AspNetCore.Mvc;
using Nike_clone_Backend.Services.UserService;

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
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult AddUser()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok();
        }
    }
}

