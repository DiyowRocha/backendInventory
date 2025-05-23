using backendInventory.Application.Mapping;
using backendInventory.Application.Services.Buildings.DTO;
using backendInventory.Application.Services.Buildings.ViewModel;
using backendInventory.Domain.Models;

namespace backendInventory.Application.Services.Buildings.Mapper;

public class BuildingMapping : MappingProfile
{
    public BuildingMapping()
    {
        CreateMap<BuildingDTO, Building>();
        CreateMap<Building, BuildingViewModel>()
            .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name));
    }
}