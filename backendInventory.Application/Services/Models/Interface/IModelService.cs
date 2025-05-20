using backendInventory.Application.Services.Models.DTO;
using backendInventory.Application.Services.Models.ViewModel;

namespace backendInventory.Application.Services.Models.Interface;

public interface IModelService
{
    Task<ModelViewModel> CreateModelAsync(ModelDTO modelDTO);
    Task<IEnumerable<ModelViewModel>> GetAllModelsAsync();
    Task<ModelViewModel> GetModelByIdAsync(int id);
    Task<ModelViewModel> UpdateModelAsync(ModelDTO modelDTO, int id);
    Task<bool> DeleteModelAsync(int id);
}