using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioStuff : ControllerBase  // /api/StudioStuff
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("get test");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("post test");
        }
        
    }
}
