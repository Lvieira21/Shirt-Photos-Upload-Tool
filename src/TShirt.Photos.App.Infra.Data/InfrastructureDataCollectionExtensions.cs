namespace TShirt.Photos.App.Infra.Data;

using Context;
using Domain.Helpers;
using Domain.Repositories;
using Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

public static class InfrastructureDataCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IShirtRepository, ShirtRepository>();
        services.AddScoped<IShirtImageRepository, ShirtImageRepository>();
        services.AddScoped<IShirtImageHelper, ShirtImageHelper>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
