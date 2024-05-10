using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nike_clone_Backend.Database;
using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Repositories.PermissionRepository
{
    public class PermissionRepository : GenericRepository<PermissionModel>
    {
        public PermissionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}