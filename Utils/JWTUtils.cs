using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Nike_clone_Backend.Models;
using Nike_clone_Backend.Models.DTOs;
using Nike_clone_Backend.UnitOfWork;

namespace Nike_clone_Backend.Utils
{
    public class JwtUtils(IConfiguration configuration)
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new();

        public string GenerateAccessToken(UserModel user)
        {
            var jwtKey = configuration["Jwt:ACCESS_KEY"];
            if (jwtKey == null)
            {
                throw new Exception("Jwt key not found");
            }
            var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
            var signingKey = new SymmetricSecurityKey(keyBytes);
            var expires = DateTime.UtcNow.AddHours(configuration.GetValue<int>("Jwt:ACCESS_TOKEN_EXPIRE"));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var subs = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role?.Name ?? "") // Added null check for user.Role.Name
                ]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subs,
                Expires = expires,
                SigningCredentials = credentials
            };
            return _jwtSecurityTokenHandler.WriteToken(_jwtSecurityTokenHandler.CreateToken(tokenDescriptor));
        }
        public string GenerateRefreshToken(string id, string email)
        {
            var jwtKey = configuration["Jwt:REFRESH_KEY"] ?? throw new Exception("Jwt key not found");
            var jwtExpire = configuration["Jwt:REFRESH_TOKEN_EXPIRE"];
            var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
            var signingKey = new SymmetricSecurityKey(keyBytes);
            var subs = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                    new Claim(ClaimTypes.Email, email),
                ]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subs,
                Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(jwtExpire)),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            return _jwtSecurityTokenHandler.WriteToken(token);
        }
        public string ValidateRefreshToken(RefreshTokenDto refreshToken)
        {
            try
            {
                var jwtKey = configuration["Jwt:REFRESH_KEY"] ?? throw new Exception("Jwt key not found");
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey));
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
                var principal = _jwtSecurityTokenHandler.ValidateToken(refreshToken.RefreshToken, tokenValidationParameters, out var securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new SecurityTokenException("Invalid token");
                }
                var claim = principal.FindFirst(ClaimTypes.Email) ?? throw new Exception("Invalid token");
                return claim.Value;
            }
            catch (Exception)
            {
                throw new Exception("Invalid token");
            }
        }
    }
}