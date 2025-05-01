using E_Commerce.Bll.Dtos.CartDTOs;
using E_Commerce.Bll.Dtos.CartProductDTOs;

namespace E_Commerce.Bll.Services.CartService;

public interface ICartService
{
    Task AddProductToCartAsync(CartProductCreateDto cartProductCreateDto);
    Task<CartGetDto> GetCartByCustomerIdAsync(long customerId);

}