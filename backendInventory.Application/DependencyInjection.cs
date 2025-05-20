using backendInventory.Application.Services.Buildings.Interface;
using backendInventory.Application.Services.Buildings.Service;
using backendInventory.Application.Services.Departments.Interface;
using backendInventory.Application.Services.Departments.Service;
using backendInventory.Application.Services.Manufacturers.Interface;
using backendInventory.Application.Services.Manufacturers.Service;
using backendInventory.Application.Services.Models.Interface;
using backendInventory.Application.Services.Models.Service;
using backendInventory.Application.Services.Printers.Interface;
using backendInventory.Application.Services.Printers.Service;
using backendInventory.Application.Services.Units.Interface;
using backendInventory.Application.Services.Units.Service;
using Microsoft.Extensions.DependencyInjection;

namespace backendInventory.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IManufacturerService, ManufacturerService>();
        services.AddScoped<IModelService, ModelService>();
        services.AddScoped<IUnitService, UnitService>();
        services.AddScoped<IBuildingService, BuildingService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IPrinterService, PrinterService>();

        return services;
    }
}