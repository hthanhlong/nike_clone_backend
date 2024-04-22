using System.ComponentModel.DataAnnotations;

namespace Reformation.Dtos
{
    public class GetUserDto
    {
        public required string Name { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    }
}