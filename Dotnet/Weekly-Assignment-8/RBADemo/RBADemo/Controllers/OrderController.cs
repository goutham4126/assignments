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
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == dto.ProductId);

            if (product == null)
                return NotFound("Product not found");

            if (dto.Quantity <= 0)
                return BadRequest("Quantity must be greater than 0");

            var totalCost = product.Price * dto.Quantity;

            var customerId = User.FindFirst("id")?.Value;

            var order = new Order
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                TotalCost = totalCost,
                CustomerId = customerId
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> GetMyOrders()
        {
            var customerId = User.FindFirst("id")?.Value;

            var orders = await _context.Orders
                .Include(o => o.Product)
                .Where(o => o.CustomerId == customerId)
                .Select(o => new
                {
                    o.Id,
                    ProductName = o.Product.Name,
                    o.Quantity,
                    o.TotalCost,
                    o.CreatedAt
                })
                .ToListAsync();

            return Ok(orders);
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var customerId = User.FindFirst("id")?.Value;

            var order = await _context.Orders
                .Include(o => o.Product)
                .FirstOrDefaultAsync(o => o.Id == id && o.CustomerId == customerId);

            if (order == null)
                return NotFound("Order not found");

            return Ok(order);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.Product)
                .Select(o => new
                {
                    o.Id,
                    o.CustomerId,
                    ProductName = o.Product.Name,
                    o.Quantity,
                    o.TotalCost,
                    o.CreatedAt
                })
                .ToListAsync();

            return Ok(orders);
        }
    }
}