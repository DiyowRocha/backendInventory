using AutoMapper;
using backendInventory.Application.Services.Units.DTO;
using backendInventory.Application.Services.Units.Interface;
using backendInventory.Application.Services.Units.ViewModel;
using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Repository.Interface;

namespace backendInventory.Application.Services.Units.Service;

public class UnitService : IUnitService
{

    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;

    public UnitService(IUnitRepository unitRepository, IMapper mapper)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
    }


    public async Task<UnitViewModel> CreateUnitAsync(UnitDTO unitDTO)
    {
        var unit = _mapper.Map<Unit>(unitDTO);

        await _unitRepository.Add(unit);

        return _mapper.Map<UnitViewModel>(unit);
    }

    public async Task<IEnumerable<UnitViewModel>> GetAllUnitsAsync()
    {
        var units = await _unitRepository.GetAll();

        return _mapper.Map<IEnumerable<UnitViewModel>>(units);
    }

    public async Task<UnitViewModel> GetUnitByIdAsync(int id)
    {
        var unit = await _unitRepository.GetById(id);

        return _mapper.Map<UnitViewModel>(unit);
    }

    public async Task<UnitViewModel> UpdateUnitAsync(UnitDTO unitDTO, int id)
    {
        var unit = await _unitRepository.GetById(id);

        if (unit is null)
            return null;

        unit.Name = unitDTO.Name;
        unit.Address = unitDTO.Address;
        unit.Number = unitDTO.Number;
        unit.Neighborhood = unitDTO.Neighborhood;
        unit.City = unitDTO.City;
        unit.State = unitDTO.State;
        unit.State = unitDTO.State;
        unit.ZipCode = unitDTO.ZipCode;

        _unitRepository.Update(unit);

        return _mapper.Map<UnitViewModel>(unit);
    }

    public async Task<bool> DeleteUnitAsync(int id)
    {
        var unit = await _unitRepository.GetById(id);

        if (unit is null)
            return false;

        return true;
    }
}