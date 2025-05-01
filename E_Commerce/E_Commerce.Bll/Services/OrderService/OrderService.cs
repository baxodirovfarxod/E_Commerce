using AutoMapper;
using E_Commerce.Bll.Dtos.OrderDTOs;
using E_Commerce.Bll.Dtos.OrderProductDTOs;
using E_Commerce.Dal.Entities;
using E_Commerce.Repository.Repositories.CartRepository;
using E_Commerce.Repository.Repositories.CustomerRepository;
using E_Commerce.Repository.Repositories.OrderRepository;
using FluentValidation;

namespace E_Commerce.Bll.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly IOrderRepository OrderRepository;
    private readonly ICustomerRepository CustomerRepository;
    private readonly ICartRepository CartRepository;
    private readonly IMapper Mapper;
    private readonly IValidator<OrderCreateDto> OrderCreateDtoValidator;

    public OrderService(IOrderRepository orderRepository, IValidator<OrderCreateDto> orderCreateDtoValidator, IMapper mapper, ICustomerRepository customerRepository, ICartRepository cartRepository)
    {
        OrderRepository = orderRepository;
        OrderCreateDtoValidator = orderCreateDtoValidator;
        Mapper = mapper;
        CustomerRepository = customerRepository;
        CartRepository = cartRepository;
    }

    public async Task<OrderGetDto> CreateOrderAsync(OrderCreateDto orderCreateDto)
    {
        var validationResult = await OrderCreateDtoValidator.ValidateAsync(orderCreateDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var customer = await CustomerRepository.SelectCustomerByIdAsync(orderCreateDto.CustomerId);
        if (customer == null)
        {
            throw new Exception("Customer not found.");
        }

        var cart = await CartRepository.SelectCartByCustomerIdAsync(orderCreateDto.CustomerId);
        if (cart == null || !cart.CartProducts.Any())
        {
            throw new Exception("Cart is empty or not found");
        }

        var order = Mapper.Map<Order>(orderCreateDto);
        order.TotalAmount = cart.CartProducts.Sum(cp => cp.Quantity * cp.Product.Price);
        order.CreatedAt = DateTime.UtcNow;
        order.OrderProducts = cart.CartProducts.Select(p => new OrderProduct
        {
            ProductId = p.ProductId,
            Quantity = p.Quantity,
            PriceAtPurchase = p.Product.Price

        }).ToList();

        await OrderRepository.InsertOrderAsync(order);

        await CartRepository.ClearCartAsync(order.CustomerId);

        return Mapper.Map<OrderGetDto>(order);

    }

    public async Task<OrderGetDto> GetOrderPreviewAsync(long customerId)
    {
        var customer = await CustomerRepository.SelectCustomerByIdAsync(customerId);
        if (customer == null)
        {
            throw new Exception("Customer not found.");
        }

        var cart = await CartRepository.SelectCartByCustomerIdAsync(customerId);
        if (cart == null || !cart.CartProducts.Any())
        {
            throw new Exception("Cart is empty or not found");
        }

        var totalAmount = cart.CartProducts.Sum(cp => cp.Quantity * cp.Product.Price);

        var OrderPreview = new OrderGetDto
        {
            CustomerId = customerId,
            TotalAmount = totalAmount,
            CreatedAt = DateTime.UtcNow,
            OrderProducts = cart.CartProducts.Select(p => new OrderProductGetDto
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity,
                PriceAtPurchase = p.Product.Price

            }).ToList()
        };

        return OrderPreview;
    }

    public async Task<List<OrderGetDto>> GetOrdersAsync(long customerId)
    {
        var orders = await OrderRepository.SelectOrdersByCustomerId(customerId);
        if (orders == null || !orders.Any())
        {
            throw new Exception("No orders found for the given customer.");
        }

        var orderGetDto = Mapper.Map<List<OrderGetDto>>(orders);

        return orderGetDto;
    }
}

