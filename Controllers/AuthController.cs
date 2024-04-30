using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Reformation.Classes;
using Reformation.Core;
using Reformation.Services.AuthService;

namespace Reformation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private IValidator<SignUpInput> _validator;
        public AuthController(IAuthService authService, IValidator<SignUpInput> validator)
        {
            _authService = authService;
            _validator = validator;
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp([FromBody] SignUpInput signUp)
        {
            try
            {
                FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(signUp);
                if (!result.IsValid)
                {
                    var Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                    return BadRequest(Errors);
                }
                await _authService.SignUp(signUp);
                return new SuccessResponse(null, "User signed up successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestResponse(ex.Message);
            }
        }
        [HttpPost("sign-in")]
        public async Task<ActionResult> SignIn([FromBody] SignInInput signInDto)
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

