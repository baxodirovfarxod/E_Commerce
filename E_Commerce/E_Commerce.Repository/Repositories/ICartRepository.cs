using E_Commerce.Dal.Entities;

namespace E_Commerce.Repository.Repositories;

public interface ICartRepository
{
    Task<Cart> CreateCartAsync(long customerId);
    Task ClearCartAsync(long customerId);
    Task<Cart> GetCartByCustomerIdAsync(long customerId);
    Task DeleteCartAsync(long customerId);
    Task UpdateCartAsync(Cart cart);
}
