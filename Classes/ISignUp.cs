using Reformation.Models;

namespace Reformation.Classes
{
    public class ISignUp
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required int RoleId { get; set; }
        public required int PermissionId  { get; set; }
    }
}

