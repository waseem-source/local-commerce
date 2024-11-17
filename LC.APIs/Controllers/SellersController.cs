using LC.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LC.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {// Mock database (replace with actual DB logic later)
        private static List<Seller> sellers = new List<Seller>
    {
        new Seller { Id = 1, Name = "John Doe", Email = "john@example.com", PhoneNumber = "1234567890", Address = "123 Main St" },
        new Seller { Id = 2, Name = "Jane Smith", Email = "jane@example.com", PhoneNumber = "9876543210", Address = "456 Elm St" }
    };

        // GET: api/sellers
        [HttpGet]
        public IActionResult GetAllSellers()
        {
            return Ok(sellers);
        }

        // GET: api/sellers/{id}
        [HttpGet("{id}")]
        public IActionResult GetSellerById(int id)
        {
            var seller = sellers.FirstOrDefault(s => s.Id == id);
            if (seller == null)
            {
                return NotFound($"Seller with Id = {id} not found.");
            }
            return Ok(seller);
        }

        // POST: api/sellers
        [HttpPost]
        public IActionResult AddSeller([FromBody] Seller newSeller)
        {
            if (newSeller == null)
            {
                return BadRequest("Invalid seller data.");
            }
            newSeller.Id = sellers.Count > 0 ? sellers.Max(s => s.Id) + 1 : 1;
            sellers.Add(newSeller);
            return CreatedAtAction(nameof(GetSellerById), new { id = newSeller.Id }, newSeller);
        }

        // PUT: api/sellers/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSeller(int id, [FromBody] Seller updatedSeller)
        {
            var existingSeller = sellers.FirstOrDefault(s => s.Id == id);
            if (existingSeller == null)
            {
                return NotFound($"Seller with Id = {id} not found.");
            }

            existingSeller.Name = updatedSeller.Name;
            existingSeller.Email = updatedSeller.Email;
            existingSeller.PhoneNumber = updatedSeller.PhoneNumber;
            existingSeller.Address = updatedSeller.Address;

            return Ok(existingSeller);
        }

        // DELETE: api/sellers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSeller(int id)
        {
            var seller = sellers.FirstOrDefault(s => s.Id == id);
            if (seller == null)
            {
                return NotFound($"Seller with Id = {id} not found.");
            }

            sellers.Remove(seller);
            return NoContent();
        }
    }
}
