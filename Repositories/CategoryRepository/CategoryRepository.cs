using Nike_clone_Backend.Database;
using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Repositories;
public class CategoryRepository : GenericRepository<CategoryModel>
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
