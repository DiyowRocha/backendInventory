using AutoMapper;
using backendInventory.Application.Services.Printers.DTO;
using backendInventory.Application.Services.Printers.Interface;
using backendInventory.Application.Services.Printers.ViewModel;
using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Repository;
using backendInventory.Infrastructure.Repository.Interface;

namespace backendInventory.Application.Services.Printers.Service;

public class PrinterService : IPrinterService
{
    private readonly IPrinterRepository _printerRepository;
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IModelRepository _modelRepository;
    private readonly IUnitRepository _unitRepository;
    private readonly IBuildingRepository _buildingRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public PrinterService(IPrinterRepository printerRepository,
                        IManufacturerRepository manufacturerRepository,
                        IModelRepository modelRepository,
                        IUnitRepository unitRepository,
                        IBuildingRepository buildingRepository,
                        IDepartmentRepository departmentRepository,
                        IMapper mapper)
    {
        _printerRepository = printerRepository;
        _manufacturerRepository = manufacturerRepository;
        _modelRepository = modelRepository;
        _unitRepository = unitRepository;
        _buildingRepository = buildingRepository;
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public async Task<PrinterViewModel> CreatePrinterAsync(PrinterDTO printerDTO)
    {
        var manufacturer = await _manufacturerRepository.GetById(printerDTO.ManufacturerId) ?? throw new Exception("Manufacturer not found.");
        var model = await _modelRepository.GetById(printerDTO.ModelId) ?? throw new Exception("Model not found.");
        var unit = await _unitRepository.GetById(printerDTO.UnitId) ?? throw new Exception("Unit not found.");
        var building = await _buildingRepository.GetById(printerDTO.BuildingId) ?? throw new Exception("Building not found.");
        var department = await _departmentRepository.GetById(printerDTO.DepartmentId) ?? throw new Exception("Department not found.");

        var printer = _mapper.Map<Printer>(printerDTO);
        printer.Manufacturer = manufacturer;
        printer.Model = model;
        printer.Unit = unit;
        printer.Building = building;
        printer.Department = department;

        await _printerRepository.Add(printer);

        return _mapper.Map<PrinterViewModel>(printer);
    }

    public async Task<IEnumerable<PrinterViewModel>> GetAllPrintersAsync()
    {
        var printers = await _printerRepository.GetAllWithAllRelations();
        return _mapper.Map<IEnumerable<PrinterViewModel>>(printers);
    }

    public async Task<PrinterViewModel> GetPrinterByIdAsync(int id)
    {
        var printer = await _printerRepository.GetByIdWithAllRelations(id);

        if (printer is null)
            return null;

        return _mapper.Map<PrinterViewModel>(printer);
    }

    public async Task<PrinterViewModel> UpdatePrinterAsync(PrinterDTO printerDTO, int id)
    {
        var printer = await _printerRepository.GetById(id) ?? throw new Exception("Printer not found.");

        var manufacturer = await _manufacturerRepository.GetById(printerDTO.ManufacturerId) ?? throw new Exception("Manufacturer not found.");
        var model = await _modelRepository.GetById(printerDTO.ModelId) ?? throw new Exception("Model not found.");
        var unit = await _unitRepository.GetById(printerDTO.UnitId) ?? throw new Exception("Unit not found.");
        var building = await _buildingRepository.GetById(printerDTO.BuildingId) ?? throw new Exception("Building not found.");
        var department = await _departmentRepository.GetById(printerDTO.DepartmentId) ?? throw new Exception("Department not found.");

        printer.SerialNumber = printerDTO.SerialNumber;
        printer.IPAddress = printerDTO.IPAddress;
        printer.PrintQueue = printerDTO.PrintQueue;

        printer.ManufacturerId = printerDTO.ManufacturerId;
        printer.ModelId = printerDTO.ModelId;
        printer.UnitId = printerDTO.UnitId;
        printer.BuildingId = printerDTO.BuildingId;
        printer.DepartmentId = printerDTO.DepartmentId;

        _printerRepository.Update(printer);

        return _mapper.Map<PrinterViewModel>(printer);
    }

    public async Task<bool> DeletePrinterAsync(int id)
    {
        var printer = await _printerRepository.GetById(id);

        if (printer is null)
            return false;

        _printerRepository.Delete(printer);

        return true;
    }
}