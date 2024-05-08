using Nike_clone_Backend.Models;
using Nike_clone_Backend.Utils;
using Nike_clone_Backend.Classes;
using Nike_clone_Backend.UnitOfWork;

namespace Nike_clone_Backend.Services.AuthService
{
    public class AuthService : GenericService, IAuthService
    {
        private readonly PasswordHarsherUtils _passwordHarsher = new PasswordHarsherUtils();
        private readonly JwtUtils _jwtUtils;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration) : base(unitOfWork)
        {
            _jwtUtils = new JwtUtils(configuration);
        }
        public async Task SignUp(ISignUp signUp)
        {
            var isUserExist = await _unitOfWork.UserRepository.GetUserByEmail(signUp.Email);
            if (isUserExist != null)
            {
                throw new Exception("User already exist");
            }
            var (hashPass, salt) = _passwordHarsher.HashPassword(signUp.Password);

            RoleModel role = await _unitOfWork.RoleRepository.GetByIDAsync(signUp.RoleId) ?? throw new Exception("Role not found");
            PermissionModel permission = await _unitOfWork.PermissionRepository.GetByIDAsync(signUp.PermissionId) ?? throw new Exception("Permission not found");

            var user = new UserModel
            {
                Email = signUp.Email,
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Password = hashPass,
                Salt = salt,
                RoleId = role.Id,
                PermissionId = permission.Id
            };
            await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.SaveAsync();
        }
        public async Task<object> SignIn(ISignIn signInDto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmail(signInDto.Email) ?? throw new Exception("User not found");
            var hashedPassword = user.Password;
            var salt = user.Salt;
            var isPasswordCorrect = _passwordHarsher.VerifyPassword(hashedPassword, signInDto.Password, salt);
            if (!isPasswordCorrect) throw new Exception("Invalid password");
            
            

            var accessToken = _jwtUtils.GenerateAccessToken(user);
            var refreshToken = _jwtUtils.GenerateRefreshToken(user.Id.ToString(), user.Email);

            RefreshTokenModel refreshTokenModel = new()
            {
                User = user,
                RefreshToken = refreshToken,
                Expires = DateTime.Now.AddDays(30),
                IsRevoked = false
            };

            await _unitOfWork.RefreshTokenRepository.Insert(refreshTokenModel);
            await _unitOfWork.SaveAsync();

            return new
            {
                UserId = user.Id,
                user.Email,
                accessToken,
                refreshToken
            };
        }

        public async Task<string?> GetNewAccessToken(IRefreshToken refreshToken)
        {
            try
            {
                RefreshTokenModel refreshTokenModel = await _unitOfWork.RefreshTokenRepository.GetByToken(refreshToken.RefreshToken) ?? throw new Exception("Refresh token not found");
                if (refreshTokenModel.IsRevoked) throw new Exception("Refresh token revoked");
                if (refreshTokenModel.Expires < DateTime.Now) throw new Exception("Refresh token expired");
                var value = _jwtUtils.ValidateRefreshToken(refreshToken);
                if (value == null) throw new Exception("Token validation failed");
                Console.WriteLine(value);
                var user = await _unitOfWork.UserRepository.GetUserByEmail(value) ?? throw new Exception("User not found");
                var accessToken = _jwtUtils.GenerateAccessToken(user);
                Console.WriteLine(accessToken);
                return accessToken;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return null;
            }
        }

        public async Task RevokeRefreshToken(IRefreshToken refreshToken)
        {
            RefreshTokenModel refreshTokenModel = await _unitOfWork.RefreshTokenRepository.GetByToken(refreshToken.RefreshToken) ?? throw new Exception("Refresh token not found");
            refreshTokenModel.IsRevoked = true;
            await _unitOfWork.SaveAsync();
        }
    }

}


