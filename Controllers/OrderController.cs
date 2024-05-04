using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Nike_clone_Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {

        public OrderController()
        {
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddOrder()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            return Ok();
        }
    }
}

