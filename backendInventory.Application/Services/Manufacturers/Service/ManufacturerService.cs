using AutoMapper;
using backendInventory.Application.Services.Manufacturers.DTO;
using backendInventory.Application.Services.Manufacturers.Interface;
using backendInventory.Application.Services.Manufacturers.ViewModel;
using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Repository.Interface;

namespace backendInventory.Application.Services.Manufacturers.Service;

public class ManufacturerService : IManufacturerService
{
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IMapper _mapper;

    public ManufacturerService(IManufacturerRepository manufacturerRepository, IMapper mapper)
    {
        _manufacturerRepository = manufacturerRepository;
        _mapper = mapper;
    }

    public async Task<ManufacturerViewModel> CreateManufacturerAsync(ManufacturerDTO manufacturerDTO)
    {
        var manufacturer = _mapper.Map<Manufacturer>(manufacturerDTO);

        await _manufacturerRepository.Add(manufacturer);

        return _mapper.Map<ManufacturerViewModel>(manufacturer);
    }

    public async Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturers()
    {
        var manufacturers = await _manufacturerRepository.GetAll();

        return _mapper.Map<IEnumerable<ManufacturerViewModel>>(manufacturers);
    }

    public async Task<ManufacturerViewModel> GetManufacturerByIdAsync(int id)
    {
        var manufacturer = await _manufacturerRepository.GetById(id);

        return _mapper.Map<ManufacturerViewModel>(manufacturer);
    }

    public async Task<ManufacturerViewModel> UpdateManufacturerAsync(ManufacturerDTO manufacturerDTO, int id)
    {
        var manufacturer = await _manufacturerRepository.GetById(id);

        if (manufacturer is null)
            return null;

        manufacturer.Name = manufacturerDTO.Name;

        _manufacturerRepository.Update(manufacturer);

        return _mapper.Map<ManufacturerViewModel>(manufacturer);
    }

    public async Task<bool> DeleteManufacturerAsync(int id)
    {
        var manufacturer = await _manufacturerRepository.GetById(id);


        if (manufacturer is null)
            return false;

        _manufacturerRepository.Delete(manufacturer);

        return true;
    }    
}