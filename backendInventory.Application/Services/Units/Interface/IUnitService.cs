using backendInventory.Application.Services.Units.DTO;
using backendInventory.Application.Services.Units.ViewModel;

namespace backendInventory.Application.Services.Units.Interface;

public interface IUnitService
{
    Task<UnitViewModel> CreateUnitAsync(UnitDTO unitDTO);
    Task<IEnumerable<UnitViewModel>> GetAllUnitsAsync();
    Task<UnitViewModel> GetUnitByIdAsync(int id);
    Task<UnitViewModel> UpdateUnitAsync(UnitDTO unitDTO, int id);
    Task<bool> DeleteUnitAsync(int id);
}