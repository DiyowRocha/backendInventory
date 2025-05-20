using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Repository.Interface;

namespace backendInventory.Infrastructure.Repository;

public interface IPrinterRepository : IRepository<Printer>
{
    Task<IEnumerable<Printer>> GetAllWithAllRelations();
    Task<Printer?> GetByIdWithAllRelations(int id);
}