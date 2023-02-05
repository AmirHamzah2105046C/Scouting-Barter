using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scouting_barter.Server.Data;
using scouting_barter.Server.IRepository;
using scouting_barter.Shared.Domain;

namespace scouting_barter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public PaymentsController(ApplicationDbContext context)
        public PaymentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Payments
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        public async Task<IActionResult> GetPayments()
        {
            //return await _context.Payments.ToListAsync();
            var Payments = await _unitOfWork.Payments.GetAll(includes: q => q.Include(x => x.Order));
            return Ok(Payments);
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Payment>> GetPayment(int id)
        public async Task<IActionResult> GetPayment(int id)
        {
            //var Payment = await _context.Payments.FindAsync(id);
            var Payment = await _unitOfWork.Payments.Get(q => q.Id == id);

            if (Payment == null)
            {
                return NotFound();
            }

            //return Payment;
            return Ok(Payment);
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment Payment)
        {
            if (id != Payment.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Payment).State = EntityState.Modified;
            _unitOfWork.Payments.Update(Payment);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PaymentExists(id))
                if (!await PaymentExists(id))
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

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment Payment)
        {
            //_context.Payments.Add(Payment);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Payments.Insert(Payment);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPayment", new { id = Payment.Id }, Payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            //var Payment = await _context.Payments.FindAsync(id);
            var Payment = await _unitOfWork.Payments.Get(q => q.Id == id);
            if (Payment == null)
            {
                return NotFound();
            }

            //_context.Payments.Remove(Payment);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Payments.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool PaymentExists(int id)
        private async Task<bool> PaymentExists(int id)
        {
            //return _context.Payments.Any(e => e.Id == id);
            var Payment = await _unitOfWork.Payments.Get(q => q.Id == id);
            return Payment != null;
        }
    }
}
