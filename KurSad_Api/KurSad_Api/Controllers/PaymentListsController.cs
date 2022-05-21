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
    public class PaymentListsController : ControllerBase
    {
        private readonly db_sadContext _context;

        public PaymentListsController(db_sadContext context)
        {
            _context = context;
        }

        // GET: api/PaymentLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentList>>> GetPaymentLists()
        {
            return await _context.PaymentLists.ToListAsync();
        }

        // GET: api/PaymentLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentList>> GetPaymentList(int id)
        {
            var paymentList = await _context.PaymentLists.FindAsync(id);

            if (paymentList == null)
            {
                return NotFound();
            }

            return paymentList;
        }

        // PUT: api/PaymentLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentList(int id, PaymentList paymentList)
        {
            if (id != paymentList.IdPaymentList)
            {
                return BadRequest();
            }

            _context.Entry(paymentList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !PaymentListExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);

            }

            return NoContent();
        }

        // POST: api/PaymentLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentList>> PostPaymentList(PaymentList paymentList)
        {
            _context.PaymentLists.Add(paymentList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentList", new { id = paymentList.IdPaymentList }, paymentList);
        }

        // DELETE: api/PaymentLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentList(int id)
        {
            var paymentList = await _context.PaymentLists.FindAsync(id);
            if (paymentList == null)
            {
                return NotFound();
            }

            _context.PaymentLists.Remove(paymentList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentListExists(int id)
        {
            return _context.PaymentLists.Any(e => e.IdPaymentList == id);
        }
    }
}
