using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiServer.Helpers;
using WebApiServer.Models;

namespace WebApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Users/login
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody]LoginRequestModel login)
        {
            if (login == null || string.IsNullOrWhiteSpace(login.username) || string.IsNullOrWhiteSpace(login.password))
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.userName == login.username);
            if (user == null)
            {
                return NotFound();
            }
            if(!PasswordHasher.VerifyPassword(login.password, user.password))
            {
                return NotFound();
            }
            LoginResponseModel responseModel= new LoginResponseModel() 
            {
                Id= user.Id,
                userName= user.userName,
                userType = user.userType,
                identification = user.identification
            };
            return Ok(responseModel);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationDBContext.Users'  is null.");
            }
            user.password = PasswordHasher.HashPassword(user.password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
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
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
