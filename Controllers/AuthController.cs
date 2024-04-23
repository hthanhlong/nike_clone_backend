using Microsoft.AspNetCore.Mvc;
using Reformation.Core;
using Reformation.Dtos.AuthDtos;
using Reformation.Services.AuthService;

namespace Reformation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp(SignUpDto signUpDto)
        {
            try
            {
                await _authService.SignUp(signUpDto);
                return new SuccessResponse(new { }, "User signed up successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestResponse(ex.Message);
            }
        }

        [HttpPost("signin")]
        public async Task<ActionResult> SignIn(SignInDto signInDto)
        {
            try
            {
                await _authService.SignIn(signInDto);
                return new SuccessResponse(new { }, "User signed In successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestResponse(ex.Message);
            }
        }
    }
}

