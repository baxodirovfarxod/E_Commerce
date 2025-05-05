using AutoMapper;
using E_Commerce.Bll.Dtos.CartDTOs;
using E_Commerce.Bll.Dtos.CartProductDTOs;
using E_Commerce.Dal.Entities;
using E_Commerce.Repository.Repositories.CartProducts;
using E_Commerce.Repository.Repositories.CartRepository;
using E_Commerce.Repository.Repositories.CustomerRepository;
using E_Commerce.Repository.Repositories.ProductRepository;
using FluentValidation;

namespace E_Commerce.Bll.Services.CartService;

public class CartService : ICartService
{
    private readonly ICartRepository CartRepository;
    private readonly ICustomerRepository CustomerRepository;
    private readonly IProductRepository ProductRepository;
    private readonly IMapper Mapper;
    private readonly IValidator<CartProductCreateDto> CartProductValidator;
    public CartService(ICartRepository cartRepository, ICustomerRepository customerRepository, IMapper mapper, IValidator<CartCreateDto> cartValidator, IValidator<CartProductCreateDto> cartProductValidator, IProductRepository productRepository, ICartProductRepository cartProductRepository)
    {
        CartRepository = cartRepository;
        CustomerRepository = customerRepository;
        Mapper = mapper;
        CartProductValidator = cartProductValidator;
        ProductRepository = productRepository;
    }

    public async Task AddProductToCartAsync(CartProductCreateDto cartProductCreateDto)
    {

        var validationResult = await CartProductValidator.ValidateAsync(cartProductCreateDto);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var cart = await CartRepository.SelectCartByCustomerIdAsync(cartProductCreateDto.CustomerId, true);

        if (cart == null)
        {
            cart = await CartRepository.CreateCartAsync(cartProductCreateDto.CustomerId);
        }

        var customer = await CustomerRepository.SelectCustomerByIdAsync(cart.CustomerId);

        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        var product = await ProductRepository.SelectProductByIdAsync(cartProductCreateDto.ProductId);

        if (product == null)
        {
            throw new Exception("Product not found");
        }

        if (product.StockQuantity < cartProductCreateDto.Quantity)
        {
            throw new Exception("Not enough product quantity");
        }

        var existingProduct = cart.CartProducts
            .FirstOrDefault(cp => cp.ProductId == cartProductCreateDto.ProductId);

        if (existingProduct != null)
        {
            existingProduct.Quantity += cartProductCreateDto.Quantity;
        }

        else
        {
            var newCartProduct = Mapper.Map<CartProduct>(cartProductCreateDto);
            newCartProduct.CartId = cart.CartId;
            newCartProduct.ProductId = product.ProductId;

            cart.CartProducts.Add(newCartProduct);
        }

        await CartRepository.UpdateCartAsync(cart);
    }
    public async Task<CartGetDto> GetCartByCustomerIdAsync(long customerId)
    {
        var cart = await CartRepository.SelectCartByCustomerIdAsync(customerId, true);

        if (cart == null)
        {
            return new CartGetDto();
        }

        var cartDto = Mapper.Map<CartGetDto>(cart);

        return cartDto;

    }
}

