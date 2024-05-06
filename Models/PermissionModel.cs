using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Nike_clone_Backend.Models
{
    public class PermissionModel
    {
        public Guid Id { get; set; }
        [MaxLength(10)]
        public required string Action { get; set; } // create, read, update, delete
        [MaxLength(100)]
        public required string Resource { get; set; } // table name

    }
}