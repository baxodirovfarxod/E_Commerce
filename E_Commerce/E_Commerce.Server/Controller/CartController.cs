using E_Commerce.Bll.Dtos.CartDTOs;
using E_Commerce.Bll.Dtos.CartProductDTOs;
using E_Commerce.Bll.Services.CartService;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Server.Controller
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService CartService;

        public CartController(ICartService cartService)
        {
            CartService = cartService;
        }

        [HttpPost("addProduct")]
        public async Task AddProductToCartAsync(CartProductCreateDto cartProductCreateDto)
        {
            await CartService.AddProductToCartAsync(cartProductCreateDto);
        }

        [HttpGet("get")]
        public async Task<CartGetDto> GetCartByCustomerIdAsync(long customerId)
        {
            return await CartService.GetCartByCustomerIdAsync(customerId);
        }
    }
}
