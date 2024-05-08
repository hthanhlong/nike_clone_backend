using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Nike_clone_Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WarehouseController : ControllerBase
    {

        public WarehouseController()
        {
        }

        [HttpGet]
        public IActionResult GetWarehouses()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetWarehouse(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddWarehouse()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWarehouse(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWarehouse(int id)
        {
            return Ok();
        }
    }
}

