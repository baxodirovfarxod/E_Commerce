using E_Commerce.Dal.Entities;

namespace E_Commerce.Repository.Repositories.CartRepository;

public interface ICartRepository
{
    Task<Cart> CreateCartAsync(long customerId);
    Task ClearCartAsync(long customerId);
    Task<Cart?> SelectCartByCustomerIdAsync(long customerId, bool withCartProducts = false, bool withProduct = false);
    Task DeleteCartAsync(long customerId);
    Task UpdateCartAsync(Cart cart);
}
