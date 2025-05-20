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
            .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.Manufacturer.Name))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model.Name))
            .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name))
            .ForMember(dest => dest.BuildingName, opt => opt.MapFrom(src => src.Building.Name))
            .ForMember(dest => dest.Floor, opt => opt.MapFrom(src => src.Building.Floor.ToString()))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
    }
}