using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Nike_clone_Backend.Models
{
    public class PermissionModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(10)]
        public required string Action { get; init; } // create, read, update, delete
        [MaxLength(100)]
        public required string Resource { get; init; } // table name

    }
}