using backendInventory.Application.Services.Manufacturers.DTO;
using backendInventory.Application.Services.Manufacturers.ViewModel;

namespace backendInventory.Application.Services.Manufacturers.Interface;

public interface IManufacturerService
{
    Task<ManufacturerViewModel> CreateManufacturerAsync(ManufacturerDTO manufacturerDTO);
    Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturers();
    Task<ManufacturerViewModel> GetManufacturerByIdAsync(int id);
    Task<ManufacturerViewModel> UpdateManufacturerAsync(ManufacturerDTO manufacturerDTO, int id);
    Task<bool> DeleteManufacturerAsync(int id);
}