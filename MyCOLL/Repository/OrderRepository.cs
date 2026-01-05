using Microsoft.EntityFrameworkCore;
using MyCOLL.Data.Data;
using MyCOLL.Data.Models.Entities;
using MyCOLL.Interface;
using MyCOLL.Shared.Models.Dto;

namespace MyCOLL.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;
    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await _context.Orders
            .Include(o => o.Items)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }
    public async Task<IEnumerable<Order>> GetOrdersByUserId(string userId)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .Where(o => o.ClientId == userId)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }
    public async Task<IEnumerable<OrderItem>> GetSalesBySupplier(string supplierId)
    {
        return await _context.OrderItems
            .Include(oi => oi.Order)             // Para saber a data e o cliente
            .ThenInclude(o => o.Client)      // Para saber o nome do cliente
            .Include(oi => oi.Product)           // Para saber o nome e imagem do produto
            .Where(oi => oi.Product.SupplierId == supplierId) // FILTRO CRÍTICO
            .OrderByDescending(oi => oi.Order.OrderDate)
            .ToListAsync();
    }
    public async Task<Order?> GetOrderById(int id)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .ThenInclude(i => i.Product)    
            .ThenInclude(p => p.Images)
            .FirstOrDefaultAsync(o => o.Id == id);
    }
    public async Task<Product?> GetProductById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product;
    }
    public async Task AddOrder(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateOrder(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
            return;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}