using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Manager")]
public class ManagerController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public ManagerController(
        IProductRepository productRepository,
        IOrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
        var totalProducts = (await _productRepository.GetAllAsync()).Count;
        var totalOrders = (await _orderRepository.GetAllAsync()).Count;

        return Ok(new
        {
            TotalProducts = totalProducts,
            TotalOrders = totalOrders
        });
    }
}