using System.ComponentModel.DataAnnotations;

namespace Nike_clone_Backend.Models
{
    public class RoleModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(120)]
        public required string Name { get; set; }
    }
}


