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
    public class WeaponController : ControllerBase
    {
        private readonly DataContext dc;
        public WeaponController(DataContext dc)
        {
            this.dc = dc;
        }

        //GET api/weapon
        [HttpGet]
        public IActionResult GetWeapons()
        {
            var weapons = dc.Weapons.ToList();
            return Ok(weapons);
        }
    }
}
