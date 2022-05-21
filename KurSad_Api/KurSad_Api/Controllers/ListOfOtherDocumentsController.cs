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
    public class ListOfOtherDocumentsController : ControllerBase
    {
        private readonly db_sadContext _context;

        public ListOfOtherDocumentsController(db_sadContext context)
        {
            _context = context;
        }

        // GET: api/ListOfOtherDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListOfOtherDocument>>> GetListOfOtherDocuments()
        {
            return await _context.ListOfOtherDocuments.ToListAsync();
        }

        // GET: api/ListOfOtherDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListOfOtherDocument>> GetListOfOtherDocument(int id)
        {
            var listOfOtherDocument = await _context.ListOfOtherDocuments.FindAsync(id);

            if (listOfOtherDocument == null)
            {
                return NotFound();
            }

            return listOfOtherDocument;
        }

        // PUT: api/ListOfOtherDocuments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListOfOtherDocument(int id, ListOfOtherDocument listOfOtherDocument)
        {
            if (id != listOfOtherDocument.IdDocuments)
            {
                return BadRequest();
            }

            _context.Entry(listOfOtherDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !ListOfOtherDocumentExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);

            }

            return NoContent();
        }

        // POST: api/ListOfOtherDocuments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListOfOtherDocument>> PostListOfOtherDocument(ListOfOtherDocument listOfOtherDocument)
        {
            _context.ListOfOtherDocuments.Add(listOfOtherDocument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListOfOtherDocument", new { id = listOfOtherDocument.IdDocuments }, listOfOtherDocument);
        }

        // DELETE: api/ListOfOtherDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListOfOtherDocument(int id)
        {
            var listOfOtherDocument = await _context.ListOfOtherDocuments.FindAsync(id);
            if (listOfOtherDocument == null)
            {
                return NotFound();
            }

            _context.ListOfOtherDocuments.Remove(listOfOtherDocument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListOfOtherDocumentExists(int id)
        {
            return _context.ListOfOtherDocuments.Any(e => e.IdDocuments == id);
        }
    }
}
