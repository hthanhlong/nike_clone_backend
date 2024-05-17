using Microsoft.AspNetCore.Mvc;
using Nike_clone_Backend.Services;

namespace Nike_clone_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(
            IProductService productService,
            ILogger<ProductController> logger
        )
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] string sort, [FromQuery] string search, [FromQuery] string page, [FromQuery] string limit)
        {
            return Ok(_productService.GetProducts(sort, search, int.Parse(page), int.Parse(limit)));
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

