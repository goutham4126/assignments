using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RBADemo.Data;
using RBADemo.DTOs;
using RBADemo.Models;

namespace RBADemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }   

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Category,
                    p.Description,
                    p.Price
                })
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var existingProduct = await _context.Products
                .FirstOrDefaultAsync(p => p.Name == product.Name);

            if (existingProduct != null)
                return BadRequest("Product already exists");

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok("Product created successfully");
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, ProductDto productDto)
        {
            var item = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (item == null)
                return NotFound("Product not found");

            item.Name = productDto.Name;
            item.Description = productDto.Description;
            item.Price = productDto.Price;

            await _context.SaveChangesAsync();

            return Ok("Product updated successfully");
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var item = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (item == null)
                return NotFound("Product not found");

            _context.Products.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("Product deleted successfully");
        }
    }
}