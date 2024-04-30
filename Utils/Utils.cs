using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Reformation.Utils
{
    public class PasswordHasherUtils
    {

        public string GenerateSalt()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var saltChars = new char[16];
            for (int i = 0; i < saltChars.Length; i++)
            {
                saltChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(saltChars);
        }
        public string HashPassword(string password, string salt)
        {
            var hasher = new PasswordHasher<object>();
            return hasher.HashPassword(salt, password);
        }
        public bool VerifyPassword(string hashedPassword, string providedPassword, string salt)
        {
            var _hashedPassword = HashPassword(providedPassword, salt);
            return _hashedPassword == hashedPassword;
        }
    }


    public class ConfigurationCORS()
    {
        public static void CallBackMy(CorsOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            options.AddPolicy("AllowAllOrigins",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        }
    }
}

