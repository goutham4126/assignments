using Application.Interfaces;
using Backend.Application.DTOs;
using Domain.Entities;

namespace Backend.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(
        IOrderRepository orderRepository,
        IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task CreateOrderAsync(CreateOrderDto dto, int customerId)
    {
        if (dto.Quantity <= 0)
            throw new Exception("Quantity must be greater than 0");

        var product = await _productRepository.GetByIdAsync(dto.ProductId);

        if (product == null)
            throw new Exception("Product not found");

        var order = new Order
        {
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            TotalCost = product.Price * dto.Quantity,
            CustomerId = customerId
        };

        await _orderRepository.AddAsync(order);
    }

    public async Task<List<Order>> GetCustomerOrdersAsync(int customerId)
    {
        return await _orderRepository.GetByCustomerIdAsync(customerId);
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }
}