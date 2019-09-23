using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_DAL;
using Library.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        [HttpGet] // notifikacija
        public IActionResult Get()   //IActionResult - broj koji odgovara http status kodu
        {
            return Ok(Unit.Books.Get().Include(x => x.Publisher).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                Book book = Unit.Books.Get().FirstOrDefault(x => x.Id == id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(book);
                }
            }
            catch (Exception ex)
            {
                // return Unauthorized(); 401 error
                // return Forbid(); 403 error
                return BadRequest(ex);
            }
        }
        // POST: api/Publishers
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            try
            {
                book.Publisher = Unit.Publishers.Get(book.Publisher.Id);
                Unit.Books.Insert(book);
                Unit.Save();
                return Ok(book);
            }
            catch
            {
                return BadRequest();
            }
        }
        // PUT: api/Publishers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            try
            {
                book.Publisher = Unit.Publishers.Get(book.Publisher.Id);
                Unit.Books.Update(book, id);
                Unit.Save();
                return Ok(book);
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
                Book book = Unit.Books.Get(id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    Unit.Books.Delete(book);
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