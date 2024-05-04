using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Nike_clone_Backend.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public required int Version { get; set; }
        [MaxLength(400)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public required CategoryModel Category { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        [MaxLength(120)]
        public string? SellInformation { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}