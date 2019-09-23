using System;
using System.Collections.Generic;
using System.Linq;
using Library_DAL;
using Library.API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : BaseController
    {
        [HttpGet] // notifikacija
        public IActionResult Get()   //IActionResult - broj koji odgovara http status kodu
        {
            return Ok(Unit.Authors.Get().Include(p => p.Books).ToList());  // vraca sve autore
        }

        [HttpGet("{id}")]  // broj koji odgovara http status kodu
        public ActionResult Get(int id)
        {
            try
            {
                Author author = Unit.Authors.Get().FirstOrDefault(x => x.Id == id);
                if (author == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(author);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        // POST: api/Authors
        [HttpPost] 
        public ActionResult Post([FromBody] Author author)   // post = insert
        {
            try
            {
                Unit.Authors.Insert(author);
                Unit.Save();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Author author)
        {
            try
            {
                Unit.Authors.Update(author, id);
                Unit.Save();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Author author = Unit.Authors.Get(id);
                if (author == null)
                {
                    return NotFound();
                }
                else
                {
                    Unit.Authors.Delete(author);
                    Unit.Save();
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}