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
    public class StoreController : ControllerBase
    {

        public StoreController()
        {
        }

        [HttpGet]
        public IActionResult GetStores()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetStore(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddStore()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStore(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStore(int id)
        {
            return Ok();
        }
    }
}

