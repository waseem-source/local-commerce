using LC.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LC.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private static List<Order> Orders = new List<Order>(); // In-memory storage for demonstration

        // GET: api/Orders
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Orders); // Return all orders
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Invalid order data.");
            }

            // Generate a new ID (incremental for demo purposes)
            order.Id = Orders.Count == 0 ? 1 : Orders.Max(o => o.Id) + 1;

            Orders.Add(order);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        // PUT: api/Orders/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order updatedOrder)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            // Update the existing order
            order.CustomerName = updatedOrder.CustomerName;
            order.OrderDate = updatedOrder.OrderDate;
            order.TotalAmount = updatedOrder.TotalAmount;

            return NoContent(); // Return 204 No Content
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            Orders.Remove(order);
            return NoContent(); // Return 204 No Content
        }
    }
}
