using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Classes
{
    public class ISignUp
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required Guid RoleId { get; set; }
        public required Guid PermissionId { get; set; }
    }
}

