using E_Commerce.Dal;
using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository.Repositories.OrderRepository;

public class OrderRepository : IOrderRepository
{
    private readonly MainContext MainContext;

    public OrderRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<long> InsertOrderAsync(Order order)
    {
        await MainContext.Orders.AddAsync(order);
        await MainContext.SaveChangesAsync();
        return order.OrderId;
    }

    public async Task<Order?> SelectOrderByOrderId(long orderId)
    {
        return await MainContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.Payments)
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);
    }

    public async Task<List<Order>> SelectOrdersByCustomerId(long customerId)
    {
        return await MainContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.Payments)
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .Where(o => o.CustomerId == customerId)
            .ToListAsync();
    }
}

