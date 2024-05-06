using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nike_clone_Backend.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public required UserModel User { get; set; }
        public required ProductModel Product { get; set; }
        [Range(1, 100)]
        public required int Quantity { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public required decimal Total { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}




/*
    
    productModel {
        {
            id: product_id
            product_version:
        }
    }
*/