using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reformation.Dtos
{
    public class GetUserDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}