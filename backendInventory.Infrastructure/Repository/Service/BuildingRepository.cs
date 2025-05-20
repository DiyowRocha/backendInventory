using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Context;
using backendInventory.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backendInventory.Infrastructure.Repository.Service;

public class BuildingRepository : Repository<Building>, IBuildingRepository
{
    public BuildingRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Building>> GetAllWithUnitAsync()
    {
        return await _context.Buildings
            .Include(b => b.Unit)
            .ToListAsync();
    }

    public async Task<Building> GetByIdWithUnitAsync(int id)
    {
        return await _context.Buildings
            .Include(b => b.Unit)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}