using Reformation.Classes;
using Reformation.Models;

namespace Reformation.Services.AuthService
{
    public interface IAuthService
    {
        public Task SignUp(SignUpInput signUpDto);
        public Task<object> SignIn(SignInInput signInDto);
        public string GenerateAccessToken(object user);
        public string GenerateRefreshToken();
    }
}

