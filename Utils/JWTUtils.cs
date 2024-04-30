using Reformation.Models;
using Reformation.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Reformation.Classes;
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
        public string GenerateAccessToken(dynamic Id)
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
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                ]),
                Expires = DateTime.UtcNow.AddHours(_configuration.GetValue<int>("Jwt:ACCESS_TOKEN_EXPIRE")),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string GenerateRefreshToken(dynamic Id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = _configuration["Jwt:REFRESH_KEY"] ?? throw new Exception("Jwt key not found");
            var jwtExpire = _configuration["Jwt:REFRESH_TOKEN_EXPIRE"];
            var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
            var signingKey = new SymmetricSecurityKey(keyBytes);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                ]),
                Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(jwtExpire)),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string GetNewAccessToken(IRefreshToken refreshToken)
        {
            try
            {
                var jwtKey = _configuration["Jwt:REFRESH_KEY"] ?? throw new Exception("Jwt key not found");
                var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
                var signingKey = new SymmetricSecurityKey(keyBytes);
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
                var claim = principal.FindFirst(ClaimTypes.NameIdentifier) ?? throw new Exception("Invalid token");     
                Console.WriteLine(new {
                    name="claim.Value",
                    value=claim.Value
                });
                return GenerateAccessToken(claim.Value);   
            }
            catch (System.Exception)
            {
                throw new Exception("Invalid token");
            }
        }
    }
}