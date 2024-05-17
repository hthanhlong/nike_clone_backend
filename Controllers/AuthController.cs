using Microsoft.AspNetCore.Mvc;
using Nike_clone_Backend.Models.DTOs;
using Nike_clone_Backend.Shared;
using Nike_clone_Backend.Services;

namespace Nike_clone_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;
    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("sign-up")]
    public async Task<ActionResult> SignUp([FromBody] SignUpDto signUpDto)
    {
        _logger.LogDebug($"Signing up user {signUpDto}");
        await _authService.SignUp(signUpDto);
        return new SuccessResponse("User signed up successfully", null);
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult> SignIn([FromBody] SignInDto signInDto)
    {
        var tokens = await _authService.SignIn(signInDto);
        return new SuccessResponse("User signed In successfully", new
        {
            user = new
            {
                Email = signInDto.Email,
                lastName = "Doe",
                firstName = "hello"
            },
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken
        });
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult> GetNewAccessToken([FromBody] RefreshTokenDto refreshTokenDto)
    {
        string? tokens = await _authService.GetNewAccessToken(refreshTokenDto);
        Console.WriteLine(tokens);
        return new SuccessResponse("New access token generated successfully", new { AccessToken = tokens });
    }
}


