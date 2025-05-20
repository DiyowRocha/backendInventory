using backendInventory.Application.Mapping;
using backendInventory.Application.Services.Models.DTO;
using backendInventory.Application.Services.Models.ViewModel;
using backendInventory.Domain.Models;

namespace backendInventory.Application.Services.Models.Mapper;

public class ModelMapping : MappingProfile
{
    public ModelMapping()
    {
        CreateMap<ModelDTO, Model>();
        CreateMap<Model, ModelViewModel>()
            .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.Manufacturer!.Name));
    }
}