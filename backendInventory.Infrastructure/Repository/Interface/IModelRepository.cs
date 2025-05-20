using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Repository.Interface;

namespace backendInventory.Infrastructure.Repository;

public interface IModelRepository : IRepository<Model>
{
    Task<IEnumerable<Model>> GetAllWithManufacturer();
    Task<Model?> GetByIdWithManufacturer(int id);
}