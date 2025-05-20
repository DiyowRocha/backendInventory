using backendInventory.Infrastructure.Context;
using backendInventory.Infrastructure.Repository;
using backendInventory.Infrastructure.Repository.Interface;
using backendInventory.Infrastructure.Repository.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace backendInventory.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();
        services.AddScoped<IUnitRepository, UnitRepository>();
        services.AddScoped<IBuildingRepository, BuildingRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IPrinterRepository, PrinterRepository>();

        return services;
    }
}