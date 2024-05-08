using Nike_clone_Backend.Classes;

namespace Nike_clone_Backend.Services.AuthService
{
    public interface IAuthService
    {
        public Task SignUp(ISignUp signUp);
        public Task<object> SignIn(ISignIn signIn);
        public Task<string?> GetNewAccessToken(IRefreshToken refreshToken);
        public Task RevokeRefreshToken(IRefreshToken refreshToken);
    }
}

