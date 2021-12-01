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
    public class AttachmentController : ControllerBase
    {
        private readonly DataContext dc;
        public AttachmentController(DataContext dc)
        {
            this.dc = dc;
        }

        //GET api/weapon
        [HttpGet]
        public IActionResult GetAttachments()
        {
            var attachments = dc.Attachment.ToList();
            return Ok(attachments);
        }
        [Route("/[controller]/Create")]
        [HttpPost]
        public IActionResult AddAttachment(Attachment attachment)
        {
            dc.Attachment.Add(attachment);
            dc.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        [Route("/[controller]/delete/ByID")]
        public IActionResult DeleteAttachment(int id)
        {
            try
            {
                Attachment attachment = dc.Attachment.FirstOrDefault(e => e.ID == id);
                if (attachment == null)
                {
                    return NotFound("ID was not found");
                }
                else
                {
                    dc.Attachment.Remove(attachment);
                    dc.SaveChanges();
                    return Ok(attachment.name + " was succesfully deleted");
                }

            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }
    }
}
