using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<List<Order>> GetByCustomerIdAsync(int customerId);
        Task<List<Order>> GetAllAsync();
    }
}
