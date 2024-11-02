using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECLink.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestControllers : BaseController
    {
        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Ok("Hello World!");
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Test!");
        }
    }
}