using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Security.Cryptography;

namespace Nike_clone_Backend.Utils
{
    public class PasswordHarsherUtils
    {
        private const int SaltSize = 16; // You can adjust the salt size as needed

        public (string hashPass, string salt) HashPassword(string password)
        {
            byte[] salt = GenerateSalt();
            string hashPass = ComputeHash(password, salt);
            return (hashPass, Convert.ToBase64String(salt));
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            string computedHash = ComputeHash(providedPassword, saltBytes);
            return hashedPassword == computedHash;
        }

        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private string ComputeHash(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(20);
                byte[] hashWithSaltBytes = new byte[20 + SaltSize];
                Array.Copy(hashBytes, 0, hashWithSaltBytes, 0, 20);
                Array.Copy(salt, 0, hashWithSaltBytes, 20, SaltSize);
                return Convert.ToBase64String(hashWithSaltBytes);
            }
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

