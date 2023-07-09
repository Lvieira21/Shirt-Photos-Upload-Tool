namespace TShirt.Photos.App.Application;

using Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(options =>
        {
            options.AddMaps(typeof(ModelMapping).Assembly);
        });

        services.AddScoped<IShirtService, ShirtService>();
        services.AddScoped<IShirtImageService, ShirtImageService>();
        services.AddScoped<ResultService>();

        return services;
    }
}
