using E_Commerce.Bll.Dtos.CardDTOs;
using E_Commerce.Bll.Dtos.CartDTOs;
using E_Commerce.Bll.Dtos.CartProductDTOs;
using E_Commerce.Bll.MappingProfile;
using E_Commerce.Bll.Validators.CardValidators;
using E_Commerce.Bll.Validators.CartProductValidator;
using E_Commerce.Bll.Validators.CartValidator;
using FluentValidation;

namespace E_Commerce.Server.Configurations;

public static class DependencyInjectionConfigurations
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
        builder.Services.AddScoped<IValidator<CartProductCreateDto>, CartProductCreateDtoValidator>();
        builder.Services.AddScoped<IValidator<CartCreateDto>, CartCreateDtoValidator>();
        builder.Services.AddScoped<IValidator<CardCreateDto>, CardCreateDtoValidator>();
        builder.Services.AddScoped<IValidator<CardUpdateDto>, CardUpdateDtoValidator>();

    }
}
