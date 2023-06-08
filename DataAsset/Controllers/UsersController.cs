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
    public class UsersController : ControllerBase
    {
        private readonly Assignment2Context _context;
        private readonly IUserRepository _us;

        public UsersController(Assignment2Context context, IUserRepository us)
        {
            _context = context;
            _us = us;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{email}/{pass}")]
        public async Task<ActionResult<User>> GetUser(string email , string pass)
        {
          if (_us.GetUser(email, pass) == false)
          {
              return NotFound();
          }
          var users = _context.Users.FirstOrDefault(u=> u.EmailAddress== email); 
            return users ;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/{email}/{pass}")]
        public async Task<IActionResult> PutUser(int id, string email, string pass)
        {
            try
            {
                User user = new User()
                {
                    UserId = id,
                    EmailAddress = email,
                    Password = pass,
                    Source = "123",
                    FirstName = "a",
                    MiddleName = "b",
                    LastName = "c",
                    RoleId = 1,
                    PubId = 1,
                    HireDate = DateTime.Now,
                };
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Ok(ex.GetBaseException);
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{email}/{pass}")]
        public async Task<ActionResult<User>> PostUser(string email, string pass)
        {
            //if (_context.Users == null)
            //{
            //    return Problem("Entity set 'Assignment2Context.Users'  is null.");
            //}
          

            //return CreatedAtAction("GetUser", new { id = user.UserId }, user);
            try {
                User user = new User()
                {
                    EmailAddress = email,
                    Password = pass,
                    Source = "123",
                    FirstName = "a",
                    MiddleName = "b",
                    LastName = "c",
                    RoleId = 1,
                    PubId = 1,
                    HireDate = DateTime.Now,
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch(DbUpdateConcurrencyException ex) {
            return Ok(ex.GetBaseException);
            }
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'Assignment2Context.Users'  is null.");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
