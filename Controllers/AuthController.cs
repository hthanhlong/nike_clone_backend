using Microsoft.AspNetCore.Mvc;
using Reformation.Classes;
using Reformation.Core;
using Reformation.Services.AuthService;

namespace Reformation.Controllers
{
    public delegate void MyEventHandler(string message);
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
        public async Task<ActionResult> SignUp(SignUpInput signUpDto)
        {
            try
            {
                await _authService.SignUp(signUpDto);
                return new SuccessResponse(null, "User signed up successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestResponse(ex.Message);
            }
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult> SignIn(SignInInput signInDto)
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
        public ActionResult RefreshToken([FromBody] RefreshTokenInput refreshTokenDto)
        {
            Console.WriteLine(refreshTokenDto.RefreshToken);
            return Ok(new SuccessResponse(null, "Token refreshed successfully").Value);
        }
    }
}

