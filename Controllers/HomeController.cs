using Microsoft.AspNetCore.Mvc;
using Reformation.Utils;

namespace Reformation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HomeController : ControllerBase
    {
        private List<int> numbers = new List<int>()
        {
            1, 2, 3
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(numbers);
        }

        [HttpPost]
        public IActionResult Add([FromBody] NumberModel model)
        {
            numbers.Add(model.Number);
            return Ok(numbers);
        }
    }
}

