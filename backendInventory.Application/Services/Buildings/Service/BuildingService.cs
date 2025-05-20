using AutoMapper;
using backendInventory.Application.Services.Buildings.DTO;
using backendInventory.Application.Services.Buildings.Interface;
using backendInventory.Application.Services.Buildings.ViewModel;
using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Repository.Interface;

namespace backendInventory.Application.Services.Buildings.Service;

public class BuildingService : IBuildingService
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;

    public BuildingService(IBuildingRepository buildingRepository, IUnitRepository unitRepository, IMapper mapper)
    {
        _buildingRepository = buildingRepository;
        _unitRepository = unitRepository;
        _mapper = mapper;
    }

    public async Task<BuildingViewModel> CreateBuildingAsync(BuildingDTO buildingDTO)
    {
        var unit = await _unitRepository.GetById(buildingDTO.UnitId);

        if (unit is null)
            throw new Exception("Unit not found.");

        var building = _mapper.Map<Building>(buildingDTO);
        await _buildingRepository.Add(building);

        return _mapper.Map<BuildingViewModel>(building);
    }

    public async Task<IEnumerable<BuildingViewModel>> GetAllBuildingAsync()
    {
        var buildings = await _buildingRepository.GetAllWithUnitAsync();

        return _mapper.Map<IEnumerable<BuildingViewModel>>(buildings);
    }

    public async Task<BuildingViewModel> GetBuildingById(int id)
    {
        var building = await _buildingRepository.GetByIdWithUnitAsync(id);

        if (building is null)
            return null;

        return _mapper.Map<BuildingViewModel>(building);
    }

    public async Task<BuildingViewModel> UpdateBuildingAsync(BuildingDTO buildingDTO, int id)
    {
        var building = await _buildingRepository.GetById(id);
        if (building is null)
            return null;

        var unit = await _unitRepository.GetById(buildingDTO.UnitId);
        if (unit is null)
            throw new Exception("Unit not found.");

        building.Name = buildingDTO.Name;
        building.Floor = buildingDTO.Floor;
        building.UnitId = buildingDTO.UnitId;

        _buildingRepository.Update(building);

        return _mapper.Map<BuildingViewModel>(building);
    }

    public async Task<bool> DeleteBuildingAsync(int id)
    {
        var building = await _buildingRepository.GetById(id);

        if (building is null)
            return false;

        _buildingRepository.Delete(building);

        return true;
    }
}