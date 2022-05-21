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
    public class TypeOfCasesController : ControllerBase
    {
        private readonly db_sadContext _context;

        public TypeOfCasesController(db_sadContext context)
        {
            _context = context;
        }

        // GET: api/TypeOfCases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfCase>>> GetTypeOfCases()
        {
            return await _context.TypeOfCases.ToListAsync();
        }

        // GET: api/TypeOfCases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfCase>> GetTypeOfCase(int id)
        {
            var typeOfCase = await _context.TypeOfCases.FindAsync(id);

            if (typeOfCase == null)
            {
                return NotFound();
            }

            return typeOfCase;
        }

        // PUT: api/TypeOfCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeOfCase(int id, TypeOfCase typeOfCase)
        {
            if (id != typeOfCase.IdType)
            {
                return BadRequest();
            }

            _context.Entry(typeOfCase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !TypeOfCaseExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);

            }

            return NoContent();
        }

        // POST: api/TypeOfCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeOfCase>> PostTypeOfCase(TypeOfCase typeOfCase)
        {
            _context.TypeOfCases.Add(typeOfCase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeOfCase", new { id = typeOfCase.IdType }, typeOfCase);
        }

        // DELETE: api/TypeOfCases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeOfCase(int id)
        {
            var typeOfCase = await _context.TypeOfCases.FindAsync(id);
            if (typeOfCase == null)
            {
                return NotFound();
            }

            _context.TypeOfCases.Remove(typeOfCase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeOfCaseExists(int id)
        {
            return _context.TypeOfCases.Any(e => e.IdType == id);
        }
    }
}
