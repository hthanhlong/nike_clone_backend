using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Database;
using Reformation.Models;

namespace Reformation.Repositories.CategoryRepository
{
    public class CategoryRepository : GenericRepository<CategoryModel>
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}