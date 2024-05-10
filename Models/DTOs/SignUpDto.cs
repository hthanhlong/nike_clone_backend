namespace Nike_clone_Backend.Models.DTOs;

public class SignUpDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required Guid RoleId { get; set; }
    public required Guid PermissionId { get; set; }
}

