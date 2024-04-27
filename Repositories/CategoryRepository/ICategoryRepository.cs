using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryModel>> GetCategories();
        Task<CategoryModel> GetCategory(int id);
        Task<CategoryModel> AddCategory(CategoryModel category);
        Task<CategoryModel> UpdateCategory(CategoryModel category);
        Task<CategoryModel> DeleteCategory(int id);
    }
}

