using E_Commerce.Dal;
using E_Commerce.Dal.Entities;
using E_Commerce.Repository.Repositories;

namespace E_Commerce.Repository.CartProducts
{
    public class CartProductRepository : ICartProductRepository
    {
        private readonly MainContext _context;

        public CartProductRepository(MainContext context)
        {
            _context = context;
        }

        public async Task DeleteCartProductByIdAsync(long cartProductId)
        {
            var entity = await _context.CartProducts.FindAsync(cartProductId);
            if (entity is not null)
            {
                _context.CartProducts.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public Task<long> InsertCartProductAsync(CartProduct cartProduct)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartProduct>> SelectCartProductsByCartIdAsync(long cartId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCartProductAsync(CartProduct cartProduct)
        {
            throw new NotImplementedException();
        }
    }
}
