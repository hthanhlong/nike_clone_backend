using Nike_clone_Backend.Models;
using Nike_clone_Backend.Utils;
using Nike_clone_Backend.UnitOfWork;
using Nike_clone_Backend.Models.DTOs;
using AutoMapper;
using System.Reflection;
using nike_clone_backend.Shared.ErrorsExceptions;

namespace Nike_clone_Backend.Services.AuthService
{
    public class AuthService : GenericService, IAuthService
    {
        private readonly PasswordHarsherUtils _passwordHarsher = new PasswordHarsherUtils();
        private readonly JwtUtils _jwtUtils;

        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration) : base(unitOfWork)
        {
            _jwtUtils = new JwtUtils(configuration);
            _mapper = mapper;
        }
        public async Task SignUp(SignUpDto signUp)
        {
            var isUserExist = await _unitOfWork.UserRepository.GetUserByEmail(signUp.Email);
            if (isUserExist != null)
            {
                throw new CustomException("User already exist", 400);
            }
            var (hashPass, salt) = _passwordHarsher.HashPassword(signUp.Password);
            var roleId = signUp.RoleId;
            if (await _unitOfWork.RoleRepository.GetByIDAsync(roleId) == null)
            {
                roleId = Guid.Parse("39EF37C0-264C-45E5-A0B6-7A529AA39157");
            }
            var permissionId = signUp.PermissionId;
            if (await _unitOfWork.PermissionRepository.GetByIDAsync(permissionId) == null)
            {
                permissionId = Guid.Parse("346F128A-1A57-448F-9B7E-87CD84ED31EF");
            }
            var user = new UserModel
            {
                Email = signUp.Email,
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Password = hashPass,
                Salt = salt,
                RoleId = roleId,
                PermissionId = permissionId
            };
            await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.SaveAsync();
        }
        public async Task<object> SignIn(SignInDto signInDto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmail(signInDto.Email) ?? throw new CustomException("User not found", 404);
            var hashedPassword = user.Password;
            var salt = user.Salt;
            var isPasswordCorrect = _passwordHarsher.VerifyPassword(hashedPassword, signInDto.Password, salt);
            if (!isPasswordCorrect) throw new CustomException("Invalid password", 400);



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

        public async Task<string?> GetNewAccessToken(RefreshTokenDto refreshToken)
        {
            try
            {
                RefreshTokenModel refreshTokenModel = await _unitOfWork.RefreshTokenRepository.GetByToken(refreshToken.RefreshToken) ?? throw new CustomException("Refresh token not found", 404);
                if (refreshTokenModel.IsRevoked) throw new CustomException("Refresh token revoked", 400);
                if (refreshTokenModel.Expires < DateTime.Now) throw new CustomException("Refresh token expired", 400);
                var refreshTokenDto = new RefreshTokenDto
                {
                    RefreshToken = refreshToken.RefreshToken
                };
                var value = _jwtUtils.ValidateRefreshToken(refreshTokenDto);
                if (value == null) throw new CustomException("Token validation failed", 400);
                Console.WriteLine(value);
                var user = await _unitOfWork.UserRepository.GetUserByEmail(value) ?? throw new CustomException("User not found", 404);
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

        public async Task RevokeRefreshToken(RefreshTokenDto refreshToken)
        {
            RefreshTokenModel refreshTokenModel = await _unitOfWork.RefreshTokenRepository.GetByToken(refreshToken.RefreshToken) ?? throw new CustomException("Refresh token not found", 404);
            refreshTokenModel.IsRevoked = true;
            await _unitOfWork.SaveAsync();
        }
    }

}


