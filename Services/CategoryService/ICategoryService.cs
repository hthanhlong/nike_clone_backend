using Nike_clone_Backend.Models;
using Nike_clone_Backend.Models.DTOs;

namespace Nike_clone_Backend.Services;
public interface ICategoryService
{
    Task<CategoryModel?> GetCategory(int id);
    Task<List<CategoryModel>> GetCategories();
    Task<CreateCategoryDto> AddCategory(CreateCategoryDto category);
    Task<CategoryModel> UpdateCategory(CategoryModel category);
    Task DeleteCategory(int id);
}

