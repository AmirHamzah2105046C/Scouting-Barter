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
    public class OrderItemsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public OrderItemsController(ApplicationDbContext context)
        public OrderItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/OrderItems
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        public async Task<IActionResult> GetOrderItems()
        {
            //return await _context.OrderItems.ToListAsync();
            var OrderItems = await _unitOfWork.OrderItems.GetAll(includes: q => q.Include(x => x.Product));
            return Ok(OrderItems);
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        public async Task<IActionResult> GetOrderItem(int id)
        {
            //var OrderItem = await _context.OrderItems.FindAsync(id);
            var OrderItem = await _unitOfWork.OrderItems.Get(q => q.Id == id);

            if (OrderItem == null)
            {
                return NotFound();
            }

            //return OrderItem;
            return Ok(OrderItem);
        }

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItem OrderItem)
        {
            if (id != OrderItem.Id)
            {
                return BadRequest();
            }

            //_context.Entry(OrderItem).State = EntityState.Modified;
            _unitOfWork.OrderItems.Update(OrderItem);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!OrderItemExists(id))
                if (!await OrderItemExists(id))
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

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem OrderItem)
        {
            //_context.OrderItems.Add(OrderItem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.OrderItems.Insert(OrderItem);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOrderItem", new { id = OrderItem.Id }, OrderItem);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            //var OrderItem = await _context.OrderItems.FindAsync(id);
            var OrderItem = await _unitOfWork.OrderItems.Get(q => q.Id == id);
            if (OrderItem == null)
            {
                return NotFound();
            }

            //_context.OrderItems.Remove(OrderItem);
            //await _context.SaveChangesAsync();
            await _unitOfWork.OrderItems.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool OrderItemExists(int id)
        private async Task<bool> OrderItemExists(int id)
        {
            //return _context.OrderItems.Any(e => e.Id == id);
            var OrderItem = await _unitOfWork.OrderItems.Get(q => q.Id == id);
            return OrderItem != null;
        }
    }
}
