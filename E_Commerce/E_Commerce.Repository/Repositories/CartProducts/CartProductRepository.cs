using E_Commerce.Dal;
using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository.Repositories.CartProducts
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

        public async Task<long> InsertCartProductAsync(CartProduct cartProduct)
        {
            _context.CartProducts.Add(cartProduct);
            await _context.SaveChangesAsync();
            return cartProduct.CartId;
        }

        public async Task<List<CartProduct>> SelectCartProductsByCartIdAsync(long cartId)
        {
            return await _context.CartProducts
                .Where(x => x.CartId == cartId)
                .ToListAsync();

        }

        public async Task UpdateCartProductAsync(CartProduct cartProduct)
        {
            _context.CartProducts.Update(cartProduct);
            await _context.SaveChangesAsync();
        }
    }
}
