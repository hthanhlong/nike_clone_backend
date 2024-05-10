namespace Nike_clone_Backend.Models.DTOs;

public class CreatePermissionDto
{
    public required string Action { get; set; }
    public required string Resource { get; set; }
}
