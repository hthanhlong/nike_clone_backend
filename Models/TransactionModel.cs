using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reformation.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}