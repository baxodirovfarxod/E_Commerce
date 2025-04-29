using E_Commerce.Bll.MappingProfile;

namespace E_Commerce.Server.Configurations;

public static class DependencyInjectionConfigurations
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
    }
}
