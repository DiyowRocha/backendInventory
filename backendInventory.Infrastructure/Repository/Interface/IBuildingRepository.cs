using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Repository.Interface;

namespace backendInventory.Infrastructure.Repository.Interface;

public interface IBuildingRepository : IRepository<Building>
{
    Task<IEnumerable<Building>> GetAllWithUnitAsync();
    Task<Building> GetByIdWithUnitAsync(int id);
}