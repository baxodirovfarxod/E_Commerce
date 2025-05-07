using AutoMapper;
using E_Commerce.Bll.Dtos.OrderDTOs;
using E_Commerce.Bll.Dtos.OrderProductDTOs;
using E_Commerce.Dal.Entities;
using E_Commerce.Repository.Repositories.CartRepository;
using E_Commerce.Repository.Repositories.CustomerRepository;
using E_Commerce.Repository.Repositories.OrderProductRepository;
using E_Commerce.Repository.Repositories.OrderRepository;
using E_Commerce.Repository.Repositories.ProductRepository;
using FluentValidation;

namespace E_Commerce.Bll.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly IOrderRepository OrderRepository;
    private readonly IMapper Mapper;
    private readonly IValidator<OrderCreateDto> OrderCreateDtoValidator;
    private readonly ICustomerRepository CustomerRepository;
    private readonly IProductRepository ProductRepository;
    private readonly ICartRepository CartRepository;
    private readonly IOrderProductRepository OrderProductRepository;

    public OrderService(IOrderRepository orderRepository, IMapper mapper, IValidator<OrderCreateDto> orderCreateDtoValidator, ICustomerRepository customerRepository, ICartRepository cartRepository, IProductRepository productRepository, IOrderProductRepository orderProductRepository)
    {
        OrderRepository = orderRepository;
        Mapper = mapper;
        OrderCreateDtoValidator = orderCreateDtoValidator;
        CustomerRepository = customerRepository;
        CartRepository = cartRepository;
        ProductRepository = productRepository;
        OrderProductRepository = orderProductRepository;
    }

    public async Task<OrderGetDto> CreateOrderAsync(OrderCreateDto orderCreateDto)
    {
        var validationResult = OrderCreateDtoValidator.Validate(orderCreateDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var customer = await CustomerRepository.SelectCustomerByIdAsync(orderCreateDto.CustomerId, true);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        var cart = await CartRepository.SelectCartByCustomerIdAsync(customer.CustomerId, true, true);
        if (cart == null )
        {
            throw new Exception("Cart not found");
        }
        if (cart.CartProducts == null || cart.CartProducts.Count == 0)
        {
            throw new Exception("Cart is empty");
        }

        var totalSum = cart.CartProducts.Sum(x => x.Product.Price * x.Quantity);
        var servicePrice = totalSum * 0.1m;
        totalSum = totalSum + servicePrice - orderCreateDto.Discount;
        totalSum = totalSum - totalSum * orderCreateDto.DiscountPercentage / 100;

        var order = new Order()
        {
            CustomerId = customer.CustomerId,
            CreatedAt = DateTime.Now,
            TotalAmount = totalSum,
            Discount = orderCreateDto.Discount,
            DiscountPercentage = orderCreateDto.DiscountPercentage,
            ServicePrice = servicePrice,
            Status = 0,
        };

        var orderId = await OrderRepository.InsertOrderAsync(order);
        var orderProducts = new List<OrderProduct>();
        foreach (var cartProduct in cart.CartProducts)
        {
            if (cartProduct.Quantity > cartProduct.Product.StockQuantity)
            {
                throw new Exception("Product stockQuantity yetarli emas !");
            }
            var orderProduct = new OrderProduct()
            {
                OrderId = orderId,
                ProductId = cartProduct.ProductId,
                Quantity = cartProduct.Quantity,
                PriceAtPurchase = cartProduct.Product.Price
            };
            orderProducts.Add(orderProduct);
            cartProduct.Product.StockQuantity -= cartProduct.Quantity;
            await ProductRepository.UpdateProductAsync(cartProduct.Product);
            await OrderProductRepository.InsertOrderProductAsync(orderProduct);
        }

        await CartRepository.ClearCartAsync(customer.CustomerId);

        var orderWithProducts = await OrderRepository.SelectOrderByOrderId(orderId);
        return Mapper.Map<OrderGetDto>(orderWithProducts);
    }

    public async Task<OrderGetDto> GetOrderPreviewAsync(long customerId)
    {
        var customer = await CustomerRepository.SelectCustomerByIdAsync(customerId, true);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        var cart = await CartRepository.SelectCartByCustomerIdAsync(customerId, true, true);
        if (cart == null)
        {
            throw new Exception("Cart not found");
        }
        if (cart.CartProducts == null || cart.CartProducts.Count == 0)
        {
            throw new Exception("Cart is empty");
        }

        var orderProducts = new List<OrderProduct>();
        foreach (var cartProduct in cart.CartProducts)
        {
            var orderProduct = new OrderProduct()
            {
                ProductId = cartProduct.ProductId,
                Quantity = cartProduct.Quantity,
                PriceAtPurchase = cartProduct.Product.Price
            };
            orderProducts.Add(orderProduct);
            cartProduct.Product.StockQuantity -= cartProduct.Quantity;
            await ProductRepository.UpdateProductAsync(cartProduct.Product);
        }

        var totalSum = cart.CartProducts.Sum(x => x.Product.Price * x.Quantity);
        var servicePrice = totalSum * 0.1m;

        var orderPreview = new OrderGetDto()
        {
            CustomerId = customer.CustomerId,
            TotalAmount = totalSum + servicePrice,
            ServicePrice = servicePrice,
            OrderProducts = Mapper.Map<List<OrderProductGetDto>>(orderProducts),
        };

        return orderPreview;
    }

    public async Task<List<OrderGetDto>> GetOrdersAsync(long customerId)
    {
        var orders = await OrderRepository.SelectOrdersByCustomerId(customerId);
        if (orders == null)
        {
            return new List<OrderGetDto>();
        }

        return orders.Select(o => Mapper.Map<OrderGetDto>(o)).ToList();
    }
}

