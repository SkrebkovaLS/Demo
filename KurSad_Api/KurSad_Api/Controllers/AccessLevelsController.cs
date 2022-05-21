using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KurSad_Api.Models;

namespace KurSad_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessLevelsController : ControllerBase
    {
        private readonly db_sadContext _context;

        public AccessLevelsController(db_sadContext context)
        {
            _context = context;
        }

        // GET: api/AccessLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccessLevel>>> GetAccessLevels()
        {
            return await _context.AccessLevels.ToListAsync();
        }

        // GET: api/AccessLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccessLevel>> GetAccessLevel(int id)
        {
            var accessLevel = await _context.AccessLevels.FindAsync(id);

            if (accessLevel == null)
            {
                return NotFound();
            }

            return accessLevel;
        }

        // PUT: api/AccessLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccessLevel(int id, AccessLevel accessLevel)
        {
            if (id != accessLevel.IdAccessLevel)
            {
                return BadRequest();
            }

            _context.Entry(accessLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return!AccessLevelExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/AccessLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccessLevel>> PostAccessLevel(AccessLevel accessLevel)
        {
            _context.AccessLevels.Add(accessLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccessLevel", new { id = accessLevel.IdAccessLevel }, accessLevel);
        }

        // DELETE: api/AccessLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessLevel(int id)
        {
            var accessLevel = await _context.AccessLevels.FindAsync(id);
            if (accessLevel == null)
            {
                return NotFound();
            }

            _context.AccessLevels.Remove(accessLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccessLevelExists(int id)
        {
            return _context.AccessLevels.Any(e => e.IdAccessLevel == id);
        }
    }
}
