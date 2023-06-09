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
    public class PublishersController : ControllerBase
    {
        private readonly Assignment2Context _db;
        private readonly IPublisherRepository _context;
        public PublishersController(Assignment2Context db, IPublisherRepository context)
        {
            _db = db;
            _context = context;
        }

        // GET: api/Publishers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers()
        {
          if (_context.GetList == null)
          {
              return NotFound();
          }
            return  _context.GetList();
        }

        // GET: api/Publishers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetPublisher(int id)
        {
            if (_context.getPublisherId == null)
            {
                return NotFound();
            }
            var publisher =  _context.getPublisherId(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return publisher;
        }
        // GET: api/Publishers/5
        [HttpGet("{name}/{city}")]
        public async Task<ActionResult<List<Publisher>>> GetPublisher(string name, string city)
        {
            if (_context.getPublisherId == null)
            {
                return NotFound();
            }
            var publisher = _context.getPubByValue(name, city); 

            if (publisher == null)
            {
                return NotFound();
            }

            return publisher;
        }

        [HttpPost]
        public IActionResult Post(string name, string city, string state, string country)
        {

            try
            {
                _context.AddPublisher(name,city,state,country);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(int id, string name, string city, string state, string country)
        {
            try
            {
                _context.UpdatePublisher(id, name, city, state, country);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Publishers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPublisher(int id, Publisher publisher)
        //{
        //    if (id != publisher.PubId)
        //    {
        //        return BadRequest();
        //    }

        //    _db.Entry(publisher).State = EntityState.Modified;

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //if (!PublisherExists(id))
        //{
        //    return NotFound();
        //}
        //else
        //{
        //    throw;
        //}
        //    }

        //    return NoContent();
        //}

        //// POST: api/Publishers
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Publisher>> PostPublisher(Publisher publisher)
        //{
        //  if (_context.Publishers == null)
        //  {
        //      return Problem("Entity set 'Assignment2Context.Publishers'  is null.");
        //  }
        //    _context.Publishers.Add(publisher);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPublisher", new { id = publisher.PubId }, publisher);
        //}

        // DELETE: api/Publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            try
            {
                _context.DeletePublisher(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //private bool PublisherExists(int id)
        //{
        //    return (_context.Publishers?.Any(e => e.PubId == id)).GetValueOrDefault();
        //}
    }
}
