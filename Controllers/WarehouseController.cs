using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Reformation.Controllers
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

