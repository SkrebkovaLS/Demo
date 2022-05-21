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
    public class RequestsForMaintenanceOfPremisesController : ControllerBase
    {
        private readonly db_sadContext _context;

        public RequestsForMaintenanceOfPremisesController(db_sadContext context)
        {
            _context = context;
        }

        // GET: api/RequestsForMaintenanceOfPremises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestsForMaintenanceOfPremise>>> GetRequestsForMaintenanceOfPremises()
        {
            return await _context.RequestsForMaintenanceOfPremises.ToListAsync();
        }

        // GET: api/RequestsForMaintenanceOfPremises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestsForMaintenanceOfPremise>> GetRequestsForMaintenanceOfPremise(int id)
        {
            var requestsForMaintenanceOfPremise = await _context.RequestsForMaintenanceOfPremises.FindAsync(id);

            if (requestsForMaintenanceOfPremise == null)
            {
                return NotFound();
            }

            return requestsForMaintenanceOfPremise;
        }

        // PUT: api/RequestsForMaintenanceOfPremises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestsForMaintenanceOfPremise(int id, RequestsForMaintenanceOfPremise requestsForMaintenanceOfPremise)
        {
            if (id != requestsForMaintenanceOfPremise.IdRequestsForMaintenanceOfPremises)
            {
                return BadRequest();
            }

            _context.Entry(requestsForMaintenanceOfPremise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !RequestsForMaintenanceOfPremiseExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);

            }

            return NoContent();
        }

        // POST: api/RequestsForMaintenanceOfPremises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestsForMaintenanceOfPremise>> PostRequestsForMaintenanceOfPremise(RequestsForMaintenanceOfPremise requestsForMaintenanceOfPremise)
        {
            _context.RequestsForMaintenanceOfPremises.Add(requestsForMaintenanceOfPremise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestsForMaintenanceOfPremise", new { id = requestsForMaintenanceOfPremise.IdRequestsForMaintenanceOfPremises }, requestsForMaintenanceOfPremise);
        }

        // DELETE: api/RequestsForMaintenanceOfPremises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestsForMaintenanceOfPremise(int id)
        {
            var requestsForMaintenanceOfPremise = await _context.RequestsForMaintenanceOfPremises.FindAsync(id);
            if (requestsForMaintenanceOfPremise == null)
            {
                return NotFound();
            }

            _context.RequestsForMaintenanceOfPremises.Remove(requestsForMaintenanceOfPremise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestsForMaintenanceOfPremiseExists(int id)
        {
            return _context.RequestsForMaintenanceOfPremises.Any(e => e.IdRequestsForMaintenanceOfPremises == id);
        }
    }
}
