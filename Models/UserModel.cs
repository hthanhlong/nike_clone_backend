using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nike_clone_Backend.Models
{
    public class UserModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(120)]
        public required string FirstName { get; set; }
        [MaxLength(120)]
        public required string LastName { get; set; }
        [MaxLength(160), EmailAddress]
        public required string Email { get; set; }
        [MaxLength(120)]
        public required string Password { get; set; }
        public required string Salt { get; set; } = "";
        public required Guid RoleId { get; set; }
        public required Guid PermissionId { get; set; }
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
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        // Navigation properties
        public RoleModel? Role { get; set; }
        public PermissionModel? Permission { get; set; }
    }
}

