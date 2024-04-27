using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Reformation.Core;
using Reformation.Dtos;
using Reformation.Services.UserService;

namespace Reformation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
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
            try
            {
                var users = await _userService.GetUsers();
                if (users == null)
                {
                    return new NotFoundResponse("Users not found");
                }
                var newUser = _mapper.Map<List<GetUserDto>>(users); // Mapping the UserModel to GetUserDto
                return Ok(new SuccessResponse(newUser, "Users found").Value);
            }
            catch (Exception ex)
            {
                return new BadRequestResponse(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);
                if (user == null)
                {
                    return new NotFoundResponse("User not found");
                }
                GetUserDto _user = _mapper.Map<GetUserDto>(user); // convert to DTO
                return Ok(new SuccessResponse(_user, "User found").Value);
            }
            catch (Exception ex)
            {
                return new BadRequestResponse(ex.Message);
            }
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

