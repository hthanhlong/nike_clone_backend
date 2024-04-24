using Microsoft.AspNetCore.Mvc;
using Reformation.Core;
using Reformation.Dtos.AuthDtos;
using Reformation.Services.AuthService;

namespace Reformation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("sign-up")]
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

        [HttpPost("sign-in")]
        public async Task<ActionResult> SignIn(SignInDto signInDto)
        {
            try
            {
                var tokens = await _authService.SignIn(signInDto);
                return new SuccessResponse(new { tokens }, "User signed In successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestResponse(ex.Message);
            }
        }

        [HttpPost("refresh-token")]
        public ActionResult RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            Console.WriteLine(refreshTokenDto.RefreshToken);
            return Ok(new SuccessResponse(new { }, "Token refreshed successfully").Value);
        }
    }
}

