using AutoMapper;
using Nike_clone_Backend.Models;
using Nike_clone_Backend.Models.DTOs;
using Nike_clone_Backend.Repositories;

namespace Nike_clone_Backend.Services;
public class CategoryService : GenericService, ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ILogger<CategoryService> _logger;
    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryService> logger) : base(unitOfWork)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CategoryModel?> GetCategory(int id)
    {
        var result = await _unitOfWork.CategoryRepository.GetByIDAsync(id);
        return _mapper.Map<CategoryModel>(result);
    }

    public async Task<List<CategoryModel>> GetCategories()
    {
        var result = await _unitOfWork.CategoryRepository.GetAllAsync();
        if (result == null || !result.Any())
        {
            _logger.LogError("No categories found");
            return new List<CategoryModel>();
        }
        return _mapper.Map<List<CategoryModel>>(result);
    }

    public async Task<CreateCategoryDto> AddCategory(CreateCategoryDto createCategoryDto)
    {
        var categoryModel = _mapper.Map<CategoryModel>(createCategoryDto);
        await _unitOfWork.CategoryRepository.Insert(categoryModel);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<CreateCategoryDto>(categoryModel);
    }

    public async Task DeleteCategory(int id)
    {
        await _unitOfWork.CategoryRepository.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<CategoryModel> UpdateCategory(CategoryModel category)
    {
        _unitOfWork.CategoryRepository.Update(category);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<CategoryModel>(category);
    }
}

