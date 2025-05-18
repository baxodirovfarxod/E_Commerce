using E_Commerce.Bll.Dtos.CardDTOs;
using E_Commerce.Bll.Dtos.CartDTOs;
using E_Commerce.Bll.Dtos.CartProductDTOs;
using E_Commerce.Bll.Dtos.CustomerDTOs;
using E_Commerce.Bll.Dtos.OrderDTOs;
using E_Commerce.Bll.Dtos.PaymentDTOs;
using E_Commerce.Bll.Dtos.ProductDTOs;
using E_Commerce.Bll.MappingProfile;
using E_Commerce.Bll.Services.CardService;
using E_Commerce.Bll.Services.CartService;
using E_Commerce.Bll.Services.CustomerService;
using E_Commerce.Bll.Services.OrderService;
using E_Commerce.Bll.Services.ProductService;
using E_Commerce.Bll.Validators.CardValidators;
using E_Commerce.Bll.Validators.CartProductValidator;
using E_Commerce.Bll.Validators.CartValidator;
using E_Commerce.Bll.Validators.CustomerValidator;
using E_Commerce.Bll.Validators.OrderValidator;
using E_Commerce.Bll.Validators.PaymentValidator;
using E_Commerce.Bll.Validators.ProductValidator;
using E_Commerce.Repository.Repositories;
using E_Commerce.Repository.Repositories.CardRepository;
using E_Commerce.Repository.Repositories.CartProducts;
using E_Commerce.Repository.Repositories.CartRepository;
using E_Commerce.Repository.Repositories.CustomerRepository;
using E_Commerce.Repository.Repositories.OrderProductRepository;
using E_Commerce.Repository.Repositories.OrderRepository;
using E_Commerce.Repository.Repositories.Payments;
using E_Commerce.Repository.Repositories.ProductRepository;
using E_Commerce.Server.Filters;
using FluentValidation;
using static E_Commerce.Bll.Validators.ProductValidator.ProductCreateValidator;

namespace E_Commerce.Server.Configurations;

public static class DependencyInjectionConfigurations
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddScoped<IValidator<CartProductCreateDto>, CartProductCreateDtoValidator>();

        builder.Services.AddScoped<IValidator<CartCreateDto>, CartCreateDtoValidator>();

        builder.Services.AddScoped<IValidator<CardCreateDto>, CardCreateDtoValidator>();
        builder.Services.AddScoped<IValidator<CardUpdateDto>, CardUpdateDtoValidator>();

        builder.Services.AddScoped<IValidator<CustomerCreateDto>, CustomerCreateDtoValidator>();
        builder.Services.AddScoped<IValidator<CustomerUpdateDto>, CustomerUpdateDtoValidator>();

        builder.Services.AddScoped<IValidator<ProductCreateDto>, ProductCreateDtoValidator>();
        builder.Services.AddScoped<IValidator<ProductUpdateDto>, ProductUpdateValidator>();

        builder.Services.AddScoped<IValidator<PaymentCreateDto>, PaymentCreateDtoValidator>();
        builder.Services.AddScoped<IValidator<PaymentUpdateDto>, PaymentUpdateDtoValidator>();

        builder.Services.AddScoped<IValidator<OrderCreateDto>, OrderCreateDtoValidator>();


        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<ICartService, CartService>();

        builder.Services.AddScoped<ICardRepository, CardRepository>();
        builder.Services.AddScoped<ICardService, CardService>();

        builder.Services.AddScoped<ICartProductRepository, CartProductRepository>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();

        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderService, OrderService>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddScoped<IOrderProductRepository, OrderProductRepository>();

        builder.Services.AddScoped<ProductCountHeaderFilter>();
        builder.Services.AddScoped<UserAgentFilter>();

    }
}
