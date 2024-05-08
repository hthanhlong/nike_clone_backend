using Microsoft.AspNetCore.Mvc;
using Nike_clone_Backend.Models.DTOs;
using Nike_clone_Backend.Shared;
using Nike_clone_Backend.Services.AuthService;

namespace Nike_clone_Backend.Controllers;

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
    public async Task<ActionResult> SignUp([FromBody] SignUpDto signUpDto)
    {
        await _authService.SignUp(signUpDto);
        return new SuccessResponse(null, "User signed up successfully");
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult> SignIn([FromBody] SignInDto signInDto)
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
    public async Task<ActionResult> GetNewAccessToken([FromBody] RefreshTokenDto refreshTokenDto)
    {
        try
        {
            var tokens = await _authService.GetNewAccessToken(refreshTokenDto);
            Console.WriteLine(tokens);
            return new SuccessResponse(new { AccessToken = tokens }, "New access token generated successfully");
        }
        catch (Exception ex)
        {
            return new BadRequestResponse(ex.Message);
        }
    }
}


