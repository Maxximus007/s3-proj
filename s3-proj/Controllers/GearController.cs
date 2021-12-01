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
        [HttpDelete]
        [Route("/[controller]/delete/ByID")]
        public IActionResult DeleteGear(int id)
        {
            try
            {
                Gear gear = dc.Gear.FirstOrDefault(e => e.ID == id);
                if (gear == null)
                {
                    return NotFound("ID was not found");
                }
                else
                {
                    dc.Gear.Remove(gear);
                    dc.SaveChanges();
                    return Ok(gear.name + " was succesfully deleted");
                }

            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }
    }
}
