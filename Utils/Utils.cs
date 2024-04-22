using Microsoft.AspNetCore.Identity;

namespace Reformation.Utils
{
    public class PasswordHasherUtils
    {
        public string HashPassword(string password)
        {
            var hasher = new PasswordHasher<object>();
            return hasher.HashPassword(null!, password);
        }
        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null!, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}