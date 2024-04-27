using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reformation.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [MaxLength(120)]
        public required string Name { get; set; }
        [MaxLength(160), EmailAddress]
        public required string Email { get; set; }
        [MaxLength(120)]
        public required string Password { get; set; }
        public required RoleModel Role { get; set; }
        public required PermissionModel Permission { get; set; }
        public string? Image { get; set; }
        public bool IsActive { get; set; } = true;
        [MaxLength(120)]
        public string? ShippingAddress { get; set; }
        [MaxLength(160)]
        public string? BillingAddress { get; set; }
        [MaxLength(160)]
        public string? City { get; set; }
        [MaxLength(160)]
        public string? State { get; set; }
        [MaxLength(160)]
        public string? Country { get; set; }
        [MaxLength(160)]
        public string? ZipCode { get; set; }
        [MaxLength(160)]
        public string? Phone_1 { get; set; }
        [MaxLength(160)]
        public string? Phone_2 { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

