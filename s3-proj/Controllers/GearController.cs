using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using s3_proj.Data;
using s3_proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s3_proj.Controllers
{
    [Route("[controller]")]
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
        [Route("/[controller]/Create")]
        [HttpPost]
        public IActionResult AddWeapon(Gear gear)
        {
            dc.Gear.Add(gear);
            dc.SaveChanges();

            return Ok();
        }
    }
}
