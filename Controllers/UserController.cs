using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reformation.Mappers;
using Reformation.Models;
using Reformation.Services;

namespace Reformation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            var newUser = users.Select(user => user.ToDto());
            return new OkObjectResult(newUser);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserModel user)
        {
            await _userService.AddUser(user);
            return new OkObjectResult(new { message = "User created successfully" });
        }
    }
}