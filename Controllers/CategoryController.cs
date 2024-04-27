using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Reformation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {

        public CategoryController()
        {
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddCategory()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            return Ok();
        }
    }
}

