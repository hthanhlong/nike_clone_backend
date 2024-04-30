using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Database;
using Reformation.Models;

namespace Reformation.Repositories.PermissionRepository
{
    public class PermissionRepository : GenericRepository<PermissionModel>
    {
        public PermissionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}