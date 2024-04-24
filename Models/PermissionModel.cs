using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reformation.Models
{
    public class PermissionModel
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Action { get; set; }
        public required string Resource { get; set; }

    }
}