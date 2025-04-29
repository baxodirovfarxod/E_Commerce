using E_Commerce.Bll.Dtos.CartProductDTOs;
using E_Commerce.Bll.Dtos.ProductDTOs;
using E_Commerce.Bll.MappingProfile;
using E_Commerce.Bll.Validators.CartProductValidator;
using FluentValidation;
using static E_Commerce.Bll.Validators.ProductValidator.ProductCreateValidator;

namespace E_Commerce.Server.Configurations;

public static class DependencyInjectionConfigurations
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
        builder.Services.AddScoped<IValidator<CartProductCreateDto>, CartProductCreateDtoValidator>();
        builder.Services.AddScoped<IValidator<ProductCreateDto>, ProductCreateDtoValidator>();

    }
}
