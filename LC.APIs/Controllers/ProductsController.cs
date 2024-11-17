using LC.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LC.APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.50m, Quantity = 100, Description = "Sample product 1" },
            new Product { Id = 2, Name = "Product 2", Price = 20.00m, Quantity = 50, Description = "Sample product 2" }
        };

        // GET: api/Products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_products);
        }

        // GET: api/Products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest("Product is null.");
            }

            // Simulate ID auto-increment
            newProduct.Id = _products.Max(p => p.Id) + 1;
            _products.Add(newProduct);

            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }

        // PUT: api/Products/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            // Update the product properties
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Quantity = updatedProduct.Quantity;
            existingProduct.Description = updatedProduct.Description;

            return Ok(existingProduct);
        }

        // DELETE: api/Products/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            _products.Remove(product);

            return NoContent(); // 204 No Content
        }
    }
}
