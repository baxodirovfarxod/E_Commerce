using E_Commerce.Dal;
using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository.Repositories.CartRepository;

public class CartRepository : ICartRepository
{
    private readonly MainContext MainContext;

    public CartRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task ClearCartAsync(long customerId)
    {
        var cart = await SelectCartByCustomerIdAsync(customerId);

        if (cart != null)
        {
            cart.CartProducts.Clear();
            await MainContext.SaveChangesAsync();
        }
    }

    public async Task<Cart> CreateCartAsync(long customerId)
    {
        var cart = await SelectCartByCustomerIdAsync(customerId);
        if (cart == null)
        {
            cart = new Cart
            {
                CustomerId = customerId,
                CartProducts = new List<CartProduct>()
            };

            MainContext.Carts.Add(cart);
            await MainContext.SaveChangesAsync();
        }

        return cart;
    }

    public async Task DeleteCartAsync(long customerId)
    {
        var cart = await SelectCartByCustomerIdAsync(customerId);

        if (cart != null)
        {
            MainContext.Carts.Remove(cart);
            await MainContext.SaveChangesAsync();
        }
    }

    public async Task<Cart?> SelectCartByCustomerIdAsync(long customerId, bool withCartProducts = false, bool withProduct = false)
    {
        var query = MainContext.Carts.AsQueryable();

        if (withCartProducts == true)
        {
            if (withProduct == true)
            {
                query = query.Include(c => c.CartProducts)
                    .ThenInclude(cp => cp.Product);
            }
            else
            {
                query = query.Include(c => c.CartProducts);
            }
        }

        return await query.FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }

    public async Task UpdateCartAsync(Cart cart)
    {
        var cartFromDB = await SelectCartByCustomerIdAsync(cart.CustomerId);

        if (cartFromDB != null)
        {
            MainContext.Carts.Update(cart);
            await MainContext.SaveChangesAsync();
        }
    }
}
