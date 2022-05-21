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
    public class ListCasesController : ControllerBase
    {
        private readonly db_sadContext _context;

        public ListCasesController(db_sadContext context)
        {
            _context = context;
        }

        // GET: api/ListCases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListCase>>> GetListCases()
        {
            return await _context.ListCases.ToListAsync();
        }

        // GET: api/ListCases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListCase>> GetListCase(int id)
        {
            var listCase = await _context.ListCases.FindAsync(id);

            if (listCase == null)
            {
                return NotFound();
            }

            return listCase;
        }

        // PUT: api/ListCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListCase(int id, ListCase listCase)
        {
            if (id != listCase.IdCases)
            {
                return BadRequest();
            }

            _context.Entry(listCase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !ListCaseExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);

            }

            return NoContent();
        }

        // POST: api/ListCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListCase>> PostListCase(ListCase listCase)
        {
            _context.ListCases.Add(listCase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListCase", new { id = listCase.IdCases }, listCase);
        }

        // DELETE: api/ListCases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListCase(int id)
        {
            var listCase = await _context.ListCases.FindAsync(id);
            if (listCase == null)
            {
                return NotFound();
            }

            _context.ListCases.Remove(listCase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListCaseExists(int id)
        {
            return _context.ListCases.Any(e => e.IdCases == id);
        }
    }
}
