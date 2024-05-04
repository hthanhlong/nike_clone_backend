using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Services.CategoryService
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

