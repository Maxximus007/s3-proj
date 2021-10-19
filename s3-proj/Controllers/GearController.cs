using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using s3_proj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s3_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearController : ControllerBase
    {
        private readonly DataContext dc;
        public GearController(DataContext dc)
        {
            this.dc = dc;
        }

        //GET api/weapon
        [HttpGet]
        public IActionResult GetGear()
        {
            var gear = dc.Gear.ToList();
            return Ok(gear);
        }
    }
}
