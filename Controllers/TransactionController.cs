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
    public class TransactionController : ControllerBase
    {

        public TransactionController()
        {
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetTransaction(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddTransaction()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransaction(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTransaction(int id)
        {
            return Ok();
        }
    }
}

