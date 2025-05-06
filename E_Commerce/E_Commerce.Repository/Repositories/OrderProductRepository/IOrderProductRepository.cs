using E_Commerce.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Repositories.OrderProductRepository
{
    public interface IOrderProductRepository
    {
        Task<long> InsertOrderProductAsync(OrderProduct orderProduct);
        Task<List<OrderProduct>> SelectOrderProductsByOrderIdAsync(long orderId);
        Task<List<OrderProduct>> SelectOrderProductsByProductIdAsync(long productId);
    }
}
