using Microsoft.AspNetCore.Mvc;
using Nike_clone_Backend.Models.DTOs;
using Nike_clone_Backend.Services.CategoryService;

namespace Nike_clone_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetCategories());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            return Ok(_categoryService.GetCategory(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            return Ok(await _categoryService.AddCategory(createCategoryDto));
        }
    }
}

