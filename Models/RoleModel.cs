using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reformation.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        [MaxLength(120)]
        public required string Name { get; set; }
    }
}

// role model = [seller, buyer, admin]

