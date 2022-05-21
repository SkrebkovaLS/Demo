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
    public class ApplicationsForTechnicalSupportsController : ControllerBase
    {
        private readonly db_sadContext _context;

        public ApplicationsForTechnicalSupportsController(db_sadContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationsForTechnicalSupports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationsForTechnicalSupport>>> GetApplicationsForTechnicalSupports()
        {
            return await _context.ApplicationsForTechnicalSupports.ToListAsync();
        }

        // GET: api/ApplicationsForTechnicalSupports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationsForTechnicalSupport>> GetApplicationsForTechnicalSupport(int id)
        {
            var applicationsForTechnicalSupport = await _context.ApplicationsForTechnicalSupports.FindAsync(id);

            if (applicationsForTechnicalSupport == null)
            {
                return NotFound();
            }

            return applicationsForTechnicalSupport;
        }

        // PUT: api/ApplicationsForTechnicalSupports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationsForTechnicalSupport(int id, ApplicationsForTechnicalSupport applicationsForTechnicalSupport)
        {
            if (id != applicationsForTechnicalSupport.IdApplicationsForTechnicalSupport)
            {
                return BadRequest();
            }

            _context.Entry(applicationsForTechnicalSupport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !ApplicationsForTechnicalSupportExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);

            }

            return NoContent();
        }

        // POST: api/ApplicationsForTechnicalSupports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationsForTechnicalSupport>> PostApplicationsForTechnicalSupport(ApplicationsForTechnicalSupport applicationsForTechnicalSupport)
        {
            _context.ApplicationsForTechnicalSupports.Add(applicationsForTechnicalSupport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationsForTechnicalSupport", new { id = applicationsForTechnicalSupport.IdApplicationsForTechnicalSupport }, applicationsForTechnicalSupport);
        }

        // DELETE: api/ApplicationsForTechnicalSupports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationsForTechnicalSupport(int id)
        {
            var applicationsForTechnicalSupport = await _context.ApplicationsForTechnicalSupports.FindAsync(id);
            if (applicationsForTechnicalSupport == null)
            {
                return NotFound();
            }

            _context.ApplicationsForTechnicalSupports.Remove(applicationsForTechnicalSupport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationsForTechnicalSupportExists(int id)
        {
            return _context.ApplicationsForTechnicalSupports.Any(e => e.IdApplicationsForTechnicalSupport == id);
        }
    }
}
