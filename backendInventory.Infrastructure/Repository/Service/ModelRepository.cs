using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Context;
using backendInventory.Infrastructure.Repository.Service;
using Microsoft.EntityFrameworkCore;

namespace backendInventory.Infrastructure.Repository;

public class ModelRepository : Repository<Model>, IModelRepository
{
    public ModelRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Model>> GetAllWithManufacturer()
    {
        return await _context.Models
            .Include(m => m.Manufacturer)
            .ToListAsync();
    }

    public async Task<Model?> GetByIdWithManufacturer(int id)
    {
        return await _context.Models
            .Include(m => m.Manufacturer)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}