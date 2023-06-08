using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAsset.Repository;

namespace DataAsset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly Assignment2Context _db;
        private readonly IAuthorRepository _context;
        public AuthorsController(Assignment2Context db, IAuthorRepository context)
        {
            _db = db;
            _context = context;
        }
        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
          if (_context.getAll == null)
          {
              return NotFound();
          }
            return  _context.getAll();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var users = _context.getAuthorid(id);
            return users;
        }

        [HttpPost]
        public IActionResult Post(string lastname, string firstname, string phone, string address, string city, string state, string zip, string email)
        {

            try
            {
                _context.AddAuthor(lastname, firstname, phone, address, city, state, zip, email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(int id, string lastname, string firstname, string phone, string address, string city, string state, string zip, string email)
        {
            try
            {
                _context.UpdateAuthor(id, lastname, firstname, phone, address, city, state, zip, email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// PUT: api/Authors/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAuthor(int id, Author author)
        //{
        //    if (id != author.AuthorId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(author).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AuthorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Authors
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Author>> PostAuthor(Author author)
        //{
        //  if (_context.Authors == null)
        //  {
        //      return Problem("Entity set 'Assignment2Context.Authors'  is null.");
        //  }
        //    _context.Authors.Add(author);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        //}

        //// DELETE: api/Authors/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _context.DeleteAuthor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //private bool AuthorExists(int id)
        //{
        //    return (_context.Authors?.Any(e => e.AuthorId == id)).GetValueOrDefault();
        //}
    }
}
