using backendInventory.Application.Mapping;
using backendInventory.Application.Services.Manufacturers.DTO;
using backendInventory.Application.Services.Manufacturers.ViewModel;
using backendInventory.Domain.Models;

namespace backendInventory.Application.Services.Manufacturers.Mapper;

public class ManufacturerMapping : MappingProfile
{
    public ManufacturerMapping()
    {
        CreateMap<ManufacturerDTO, Manufacturer>();
        CreateMap<Manufacturer, ManufacturerViewModel>();
    }
}