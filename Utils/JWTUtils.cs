using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Reformation.Classes;
using Reformation.Models;
using Reformation.UnitOfWork;

namespace Reformation.Utils
{
    public class JWTUtils
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        public JWTUtils(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public string GenerateAccessToken(UserModel user)
        {
            var jwtKey = _configuration["Jwt:ACCESS_KEY"];
            if (jwtKey == null)
            {
                throw new Exception("Jwt key not found");
            }
            var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
            var signingKey = new SymmetricSecurityKey(keyBytes);
            var Expires = DateTime.UtcNow.AddHours(_configuration.GetValue<int>("Jwt:ACCESS_TOKEN_EXPIRE"));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var Subs = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.Name)
                ]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = Subs,
                Expires = Expires,
                SigningCredentials = credentials
            };
            return _jwtSecurityTokenHandler.WriteToken(_jwtSecurityTokenHandler.CreateToken(tokenDescriptor));
        }
        public string GenerateRefreshToken(string Id, string Email)
        {
            var jwtKey = _configuration["Jwt:REFRESH_KEY"] ?? throw new Exception("Jwt key not found");
            var jwtExpire = _configuration["Jwt:REFRESH_TOKEN_EXPIRE"];
            var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
            var signingKey = new SymmetricSecurityKey(keyBytes);
            var Subs = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                    new Claim(ClaimTypes.Email, Email),
                ]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = Subs,
                Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(jwtExpire)),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            return _jwtSecurityTokenHandler.WriteToken(token);
        }
        public string ValidateRefreshToken(IRefreshToken refreshToken)
        {
            try
            {
                var jwtKey = _configuration["Jwt:REFRESH_KEY"] ?? throw new Exception("Jwt key not found");
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey));
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
                SecurityToken securityToken;
                var principal = _jwtSecurityTokenHandler.ValidateToken(refreshToken.RefreshToken, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new SecurityTokenException("Invalid token");
                }
                var claim = principal.FindFirst(ClaimTypes.Email) ?? throw new Exception("Invalid token");
                return claim.Value;
            }
            catch (System.Exception)
            {
                throw new Exception("Invalid token");
            }
        }
    }
}