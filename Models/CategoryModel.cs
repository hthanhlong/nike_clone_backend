using System.ComponentModel.DataAnnotations;

namespace Nike_clone_Backend.Models;

public class CategoryModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(255)]
    public required string Description { get; set; }
    [MaxLength(255)]
    public string? Image { get; set; }
    [MaxLength(255)]
    public required string Slug { get; set; }
}


