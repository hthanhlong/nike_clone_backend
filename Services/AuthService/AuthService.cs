using AutoMapper;
using Reformation.Dtos;
using Reformation.Dtos.AuthDtos;
using Reformation.Models;
using Reformation.Repositories.UserRepository;
using Reformation.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Reformation.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AuthService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task SignUp(SignUpDto signUpDto)
        {
            var isUserExist = await _userRepository.GetUserByEmail(signUpDto.Email);
            if (isUserExist != null)
            {
                throw new Exception("User already exist");
            }
            var newUser = _mapper.Map<CreateUserDto>(signUpDto);
            await _userRepository.AddUser(newUser);
        }

        public async Task<object> SignIn(SignInDto signInDto)
        {
            var isUserExist = await _userRepository.GetUserByEmail(signInDto.Email);
            if (isUserExist == null)
            {
                throw new Exception("User not found");
            }
            var hashedPassword = isUserExist.Password;
            var passwordHasher = new PasswordHasherUtils();
            var isPasswordCorrect = passwordHasher.VerifyPassword(hashedPassword, signInDto.Password);
            if (!isPasswordCorrect)
            {
                throw new Exception("Invalid password");
            }

            var AccessToken = GenerateAccessToken(new
            {
                Email = isUserExist.Email,
                Id = isUserExist.Id
            });

            var refreshToken = GenerateRefreshToken();

            return new {
                AccessToken = AccessToken,
                RefreshToken = refreshToken
            };

        }
        public string GenerateAccessToken(object user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = _configuration["Jwt:ACCESS_KEY"];

            if (jwtKey == null)
            {
                throw new Exception("Jwt key not found");
            }
            var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
            var signingKey = new SymmetricSecurityKey(keyBytes);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, ((dynamic)user).Id.ToString()),
                    new Claim(ClaimTypes.Email, ((dynamic)user).Email)
                }),
                Expires = DateTime.UtcNow.AddHours(_configuration.GetValue<int>("Jwt:ACCESS_TOKEN_EXPIRE")),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = _configuration["Jwt:REFRESH_KEY"];
            var jwtExpire = _configuration["Jwt:REFRESH_TOKEN_EXPIRE"];
            if (jwtKey == null)
            {
                throw new Exception("Jwt key not found");
            }
            var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
            var signingKey = new SymmetricSecurityKey(keyBytes);
            var randomNumber = new byte[32];
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, randomNumber.ToString() ?? string.Empty)
                }),
                Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(jwtExpire)),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}


