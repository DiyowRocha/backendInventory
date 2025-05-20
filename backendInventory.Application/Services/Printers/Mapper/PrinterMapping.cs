using backendInventory.Application.Mapping;
using backendInventory.Application.Services.Printers.DTO;
using backendInventory.Application.Services.Printers.ViewModel;
using backendInventory.Domain.Models;

namespace backendInventory.Application.Services.Printers.Mapper;

public class PrinterMapping : MappingProfile
{
    public PrinterMapping()
    {
        CreateMap<PrinterDTO, Printer>();
        CreateMap<Printer, PrinterViewModel>()
            .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.Manufacturer != null ? src.Manufacturer.Name : null))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.Name : null))
            .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit != null ? src.Unit.Name : null))
            .ForMember(dest => dest.BuildingName, opt => opt.MapFrom(src => src.Building != null ? src.Building.Name : null))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : null));
    }
}