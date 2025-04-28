using E_Commerce.Dal.Entities;

namespace E_Commerce.Repository.Repositories;

public interface IOrderRepository
{
    Task<long> InsertOrderAsync(Order order);
    Task<Order> SelectOrderByOrderId(long orderId);
    Task<List<Order>> SelectOrdersByCustomerId(long customerId);
}
