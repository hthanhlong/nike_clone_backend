using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reformation.Dtos
{
    public class CreateUserDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

