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
    public class ProductController : ControllerBase
    {

        public ProductController()
        {
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddProduct()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok();
        }
    }
}

