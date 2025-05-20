using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Context;
using backendInventory.Infrastructure.Repository.Interface;

namespace backendInventory.Infrastructure.Repository.Service;

public class UnitRepository : Repository<Unit>, IUnitRepository
{
    public UnitRepository(ApplicationContext context) : base(context)
    {
    }
}