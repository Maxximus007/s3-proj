using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using s3_proj.Data;
using s3_proj.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
            dynamic data = new ExpandoObject();
            data.name = weapon.name;
            data.ID = weapon.ID;

            // convert to JSON
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            return Ok(json);
        }
        [Route("/[controller]/Edit")]
        [HttpPost]
        public IActionResult EditWeapon(Weapon weapon)
        {
            dc.Update(weapon);
            dc.SaveChanges();

            return Ok(weapon);
        }
        [Route("/[controller]/Get/ByID")]
        [HttpGet]
        public IActionResult GetWeaponByID(int id)
        {
            Weapon weapon = dc.Weapon.FirstOrDefault(e => e.ID == id);

            return Ok(weapon);
        }
        [HttpDelete]
        [Route("/[controller]/delete/ByID")]
        public IActionResult DeleteWeapon(int id)
        {
            try
            {
                Weapon weapon = dc.Weapon.FirstOrDefault(e => e.ID == id);
                if(weapon == null)
                {
                    return NotFound("{\"error\":\"ID was not found\"}");
                }
                else
                {
                    dc.Weapon.Remove(weapon);
                    dc.SaveChanges();
                    return Ok(weapon.name + " was succesfully deleted");
                }               
                
            }
                catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        
        }
    }
}
