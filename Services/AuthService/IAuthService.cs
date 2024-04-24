using Reformation.Dtos.AuthDtos;
using Reformation.Models;

namespace Reformation.Services.AuthService
{
    public interface IAuthService
    {
        public Task SignUp(SignUpDto signUpDto);
        public Task<object> SignIn(SignInDto signInDto);
        public string GenerateAccessToken(object user);
        public string GenerateRefreshToken();
    }
}

