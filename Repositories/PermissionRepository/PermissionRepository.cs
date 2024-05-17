using Nike_clone_Backend.Database;
using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Repositories;
public class PermissionRepository : GenericRepository<PermissionModel>
{
    public PermissionRepository(ApplicationDbContext context) : base(context)
    {

    }
}