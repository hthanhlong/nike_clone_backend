using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<CategoryModel?> GetCategory(int id);
        Task<IEnumerable<CategoryModel>> GetCategories();
        Task<CategoryModel> AddCategory(CategoryModel category);
        Task<CategoryModel> UpdateCategory(CategoryModel category);
        Task DeleteCategory(int id);
    }
}

