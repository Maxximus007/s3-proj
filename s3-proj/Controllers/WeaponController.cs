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
    [Route("/[controller]")]
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
            var weapons = dc.Weapon.ToList();
            return Ok(weapons);
        }
        [Route("/[controller]/Create")]
        [HttpPost]
        public IActionResult AddWeapon(Weapon weapon)
        {
            dc.Weapon.Add(weapon);
            dc.SaveChanges();

            return Ok();
        }
        [Route("/[controller]/Get/ByID")]
        [HttpGet]
        public IActionResult GetWeaponByID(int id)
        {
            Weapon weapon = dc.Weapon.FirstOrDefault(e => e.ID == id);

            return Ok(weapon);
        }
        [HttpDelete]
        [Route("/[controller]/delete/{id}")]
        public IActionResult DeleteWeapon(int id)
        {
            Weapon weapon =  dc.Weapon.FirstOrDefault(e => e.ID == id);

            dc.Weapon.Remove(weapon);
            dc.SaveChanges();
            return NoContent();
        }
    }
}
