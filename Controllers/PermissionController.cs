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
    public class PermissionController : ControllerBase
    {

        public PermissionController()
        {
        }

        [HttpGet]
        public IActionResult GetPermissions()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetPermission(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddPermission()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePermission(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePermission(int id)
        {
            return Ok();
        }
    }
}

