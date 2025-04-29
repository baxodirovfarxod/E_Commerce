using E_Commerce.Dal.Entities;

namespace E_Commerce.Repository.Repositories.CartProducts;

public interface ICartProductRepository
{
    Task<long> InsertCartProductAsync(CartProduct cartProduct);
    Task DeleteCartProductByIdAsync(long cartProductId);
    Task<List<CartProduct>> SelectCartProductsByCartIdAsync(long cartId);
    Task UpdateCartProductAsync(CartProduct cartProduct);
}
