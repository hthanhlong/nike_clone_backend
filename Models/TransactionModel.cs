using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nike_clone_Backend.Models
{
    public class TransactionModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required UserModel User { get; set; }
        public required ProductModel Product { get; set; }
        [Range(1, 100)]
        public required int Quantity { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}