using backendInventory.Application.Mapping;
using backendInventory.Application.Services.Departments.DTO;
using backendInventory.Application.Services.Departments.ViewModel;
using backendInventory.Domain.Models;

namespace backendInventory.Application.Services.Departments.Mapper;

public class DepartmentMapping : MappingProfile
{
    public DepartmentMapping()
    {
        CreateMap<DepartmentDTO, Department>();
        CreateMap<Department, DepartmentViewModel>()
            .ForMember(dest => dest.BuildingName, opt => opt.MapFrom(src => src.Building != null ? src.Building.Name : null));
    }
}