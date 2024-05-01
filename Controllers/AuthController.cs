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
        private IValidator<ISignUp> _validator;
        public AuthController(IAuthService authService, IValidator<ISignUp> validator)
        {
            _authService = authService;
            _validator = validator;
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUp([FromBody] ISignUp signUp)
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
        public async Task<ActionResult> SignIn([FromBody] ISignIn signIn)
        {
            try
            {
                var tokens = await _authService.SignIn(signIn);
                return new SuccessResponse(new { tokens }, "User signed In successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestResponse(ex.Message);
            }
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult> GetNewAccessToken([FromBody] IRefreshToken refreshToken)
        {
            try
            {
                var tokens = await _authService.GetNewAccessToken(refreshToken);
                Console.WriteLine(tokens);
                return new SuccessResponse(new { AccessToken = tokens }, "New access token generated successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestResponse(ex.Message);
            }
        }
    }
}

