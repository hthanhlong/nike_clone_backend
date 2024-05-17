using Nike_clone_Backend.Database;
using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Repositories;
public class RoleRepository : GenericRepository<RoleModel>
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {
    }


}