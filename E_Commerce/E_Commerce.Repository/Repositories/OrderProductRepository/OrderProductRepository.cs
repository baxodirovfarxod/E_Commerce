using E_Commerce.Dal;
using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository.Repositories.OrderProductRepository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly MainContext MainContext;
        public OrderProductRepository(MainContext mainContext)
        {
            MainContext = mainContext;
        }
        public async Task<long> InsertOrderProductAsync(OrderProduct orderProduct)
        {
            await MainContext.AddAsync(orderProduct);
            await MainContext.SaveChangesAsync();
            return orderProduct.OrderId;
        }

        public async Task<List<OrderProduct>> SelectOrderProductsByOrderIdAsync(long orderId)
        {
            return await MainContext.OrderProducts
            .Include(o => o.Order)
            .Include(op => op.Product)
            .Where(o => o.OrderId == orderId)
            .ToListAsync();
        }

        public async Task<List<OrderProduct>> SelectOrderProductsByProductIdAsync(long productId)
        {
            return await MainContext.OrderProducts
          .Include(o => o.Order)
          .Include(op => op.Product)
          .Where(o => o.ProductId == productId)
          .ToListAsync();
        }
    }
}
