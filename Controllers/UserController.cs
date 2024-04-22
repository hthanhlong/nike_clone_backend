using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reformation.Dtos;
using Reformation.Mappers.UserMappers;
using Reformation.Models;
using Reformation.Services.UserService;

namespace Reformation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            if (users == null)
            {
                return new NotFoundObjectResult(new { message = "Users not found" });
            }
            var newUser = _mapper.Map<List<GetUserDto>>(users); // Mapping the UserModel to GetUserDto
            return new OkObjectResult(new { users = newUser, message = "Users found", status = 200, success = true });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDto>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return new NotFoundObjectResult(new { message = "User not found" });
            }
            GetUserDto _user = _mapper.Map<GetUserDto>(user); // convert to DTO
            return new OkObjectResult(new { user = _user, message = "User found", status = 200, success = true });
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserDto>> CreateUser([FromBody] CreateUserDto user)
        {
            if (user == null)
            {
                return new BadRequestObjectResult(new { message = "User not found" });
            }
            await _userService.AddUser(user);
            return new OkObjectResult(new { message = "User created successfully" });
        }
    }
}