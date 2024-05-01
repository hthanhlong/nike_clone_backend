using Reformation.Classes;
using Reformation.Models;

namespace Reformation.Services.AuthService
{
    public interface IAuthService
    {
        public Task SignUp(ISignUp signUp);
        public Task<object> SignIn(ISignIn signIn);
        public Task<string?> GetNewAccessToken(IRefreshToken refreshToken);
        public Task RevokeRefreshToken(IRefreshToken refreshToken);
    }
}

