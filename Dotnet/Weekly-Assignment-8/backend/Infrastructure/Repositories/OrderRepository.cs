using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
            => await _context.Orders.Include(o => o.Product).ToListAsync();

        public async Task<List<Order>> GetByCustomerIdAsync(int customerId)
            => await _context.Orders
                .Include(o => o.Product)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
    }
}
