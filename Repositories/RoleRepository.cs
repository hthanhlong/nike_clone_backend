using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Database;
using Reformation.Models;

namespace Reformation.Repositories.RoleRepository
{
    public class RoleRepository : GenericRepository<RoleModel>
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}