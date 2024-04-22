using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reformation.Dtos
{
    public class GetUserDto
    {
        public required string Name { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    }
}