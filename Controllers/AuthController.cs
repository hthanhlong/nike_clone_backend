using Microsoft.AspNetCore.Mvc;
using Reformation.Dtos.AuthDtos;
using Reformation.Services.AuthService;

namespace Reformation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController
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
                var isSuccess = await _authService.SignUp(signUpDto);
                if (!isSuccess)
                {
                    return new BadRequestObjectResult(new { message = "User is existed" });
                }
                else
                {
                    return new OkObjectResult(new { message = "User created successfully" });
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message });
            }
        }

        [HttpPost("signin")]
        public async Task<ActionResult> SignIn(SignInDto signInDto)
        {
            try
            {
                var isSuccess = await _authService.SignIn(signInDto);
                if (!isSuccess)
                {
                    return new BadRequestObjectResult(new { message = "User is not existed" });
                }
                else
                {
                    return new OkObjectResult(new { message = "User signed in successfully" });
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message });
            }
        }
    }
}

