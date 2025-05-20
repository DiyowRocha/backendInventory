using backendInventory.Domain.Models;

namespace backendInventory.Infrastructure.Repository.Interface;

public interface IDepartmentRepository : IRepository<Department>
{
    Task<IEnumerable<Department>> GetAllWithBuilding();
    Task<Department> GetByIdWithBuilding(int id);
}