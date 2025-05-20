using backendInventory.Application.Mapping;
using backendInventory.Application.Services.Units.DTO;
using backendInventory.Application.Services.Units.ViewModel;
using backendInventory.Domain.Models;

namespace backendInventory.Application.Services.Units.Mapper;

public class UnitMapping : MappingProfile
{
    public UnitMapping()
    {
        CreateMap<UnitDTO, Unit>();
        CreateMap<Unit, UnitViewModel>();
    }
}