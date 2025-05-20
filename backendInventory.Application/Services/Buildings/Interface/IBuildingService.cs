using backendInventory.Application.Services.Buildings.DTO;
using backendInventory.Application.Services.Buildings.ViewModel;

namespace backendInventory.Application.Services.Buildings.Interface;

public interface IBuildingService
{
    Task<BuildingViewModel> CreateBuildingAsync(BuildingDTO buildingDTO);
    Task<IEnumerable<BuildingViewModel>> GetAllBuildingAsync();
    Task<BuildingViewModel> GetBuildingById(int id);
    Task<BuildingViewModel> UpdateBuildingAsync(BuildingDTO buildingDTO, int id);
    Task<bool> DeleteBuildingAsync(int id);
}