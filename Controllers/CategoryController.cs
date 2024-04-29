using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reformation.Models;
using Reformation.Services.CategoryService;

namespace Reformation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private IValidator<CategoryModel> _validator;
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService, IValidator<CategoryModel> validator)
        {
            _categoryService = categoryService;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_categoryService.GetCategories());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            return Ok(_categoryService.GetCategory(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryModel category)
        {
            FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(category);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            return Ok(_categoryService.AddCategory(category));
        }
    }
}

