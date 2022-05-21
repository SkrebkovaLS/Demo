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
    public class ActsOnMaterialSupportsController : ControllerBase
    {
        private readonly db_sadContext _context;

        public ActsOnMaterialSupportsController(db_sadContext context)
        {
            _context = context;
        }

        // GET: api/ActsOnMaterialSupports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActsOnMaterialSupport>>> GetActsOnMaterialSupports()
        {
            return await _context.ActsOnMaterialSupports.ToListAsync();
        }

        // GET: api/ActsOnMaterialSupports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActsOnMaterialSupport>> GetActsOnMaterialSupport(int id)
        {
            var actsOnMaterialSupport = await _context.ActsOnMaterialSupports.FindAsync(id);

            if (actsOnMaterialSupport == null)
            {
                return NotFound();
            }

            return actsOnMaterialSupport;
        }

        // PUT: api/ActsOnMaterialSupports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActsOnMaterialSupport(int id, ActsOnMaterialSupport actsOnMaterialSupport)
        {
            if (id != actsOnMaterialSupport.IdActsOnMaterialSupport)
            {
                return BadRequest();
            }

            _context.Entry(actsOnMaterialSupport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return!ActsOnMaterialSupportExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/ActsOnMaterialSupports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActsOnMaterialSupport>> PostActsOnMaterialSupport(ActsOnMaterialSupport actsOnMaterialSupport)
        {
            _context.ActsOnMaterialSupports.Add(actsOnMaterialSupport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActsOnMaterialSupport", new { id = actsOnMaterialSupport.IdActsOnMaterialSupport }, actsOnMaterialSupport);
        }

        // DELETE: api/ActsOnMaterialSupports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActsOnMaterialSupport(int id)
        {
            var actsOnMaterialSupport = await _context.ActsOnMaterialSupports.FindAsync(id);
            if (actsOnMaterialSupport == null)
            {
                return NotFound();
            }

            _context.ActsOnMaterialSupports.Remove(actsOnMaterialSupport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActsOnMaterialSupportExists(int id)
        {
            return _context.ActsOnMaterialSupports.Any(e => e.IdActsOnMaterialSupport == id);
        }
    }
}
