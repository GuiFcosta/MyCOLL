using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCOLL.Data.Models.Entities;
using MyCOLL.Interface;
using MyCOLL.Shared.Constants;

namespace MyCOLL.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    // GET: api/orders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var orders = await _orderRepository.GetAllOrders();
        return Ok(orders);
    }

    // GET: api/orders/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrderById(int id)
    {
        var order = await _orderRepository.GetOrderById(id);
        if (order == null)
            return NotFound();
        return Ok(order);
    }
    
    // POST: api/orders
    [HttpPost]
    [Authorize(Roles = UserRoles.Client)]
    public async Task<ActionResult<Order>> PostOrder(Order order)
    {
        order.OrderDate = DateTime.UtcNow; 
        
        // Associa ao utilizador logado (se o campo UserId existir)
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId != null) 
            order.ClientId = userId;

        await _orderRepository.AddOrder(order);

        return CreatedAtAction("GetOrder", new { id = order.Id }, order);
    }

    // DELETE: api/orders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _orderRepository.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }

        await _orderRepository.DeleteOrder(id);

        return NoContent();
    }
}