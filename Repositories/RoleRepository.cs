using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nike_clone_Backend.Database;
using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Repositories.RoleRepository
{
    public class RoleRepository : GenericRepository<RoleModel>
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}