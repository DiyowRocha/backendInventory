using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Context;
using backendInventory.Infrastructure.Repository.Interface;

namespace backendInventory.Infrastructure.Repository.Service;

public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository
{
    public ManufacturerRepository(ApplicationContext context) : base(context)
    {
    }
}