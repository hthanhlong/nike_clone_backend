using Reformation.Models;
using Reformation.UnitOfWork;

namespace Reformation.Services.CategoryService
{
    public class CategoryService : GenericService, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        async Task<CategoryModel?> ICategoryService.GetCategory(int id)
        {
            return await _unitOfWork.CategoryRepository.GetByIDAsync(id);
        }

        async Task<IEnumerable<CategoryModel>> ICategoryService.GetCategories()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }

        async Task<CategoryModel> ICategoryService.AddCategory(CategoryModel category)
        {
            await _unitOfWork.CategoryRepository.Insert(category);
            await _unitOfWork.SaveAsync();
            return category;
        }

        async Task ICategoryService.DeleteCategory(int id)
        {
            await _unitOfWork.CategoryRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        async Task<CategoryModel> ICategoryService.UpdateCategory(CategoryModel category)
        {
            _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return category;
        }
    }
}

