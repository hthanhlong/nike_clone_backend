
using Nike_clone_Backend.Models.DTOs;

namespace Nike_clone_Backend.Services;
public interface IAuthService
{
    public Task SignUp(SignUpDto signUp);
    public Task<(string AccessToken, string RefreshToken)> SignIn(SignInDto signIn);
    public Task<string?> GetNewAccessToken(RefreshTokenDto refreshToken);
    public Task RevokeRefreshToken(RefreshTokenDto refreshToken);
}

