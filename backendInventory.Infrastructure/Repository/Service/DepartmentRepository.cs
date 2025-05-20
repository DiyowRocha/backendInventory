using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Context;
using backendInventory.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backendInventory.Infrastructure.Repository.Service;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Department>> GetAllWithBuilding()
    {
        return await _context.Departments
            .Include(d => d.Building)
            .ToListAsync();
    }

    public async Task<Department> GetByIdWithBuilding(int id)
    {
        return await _context.Departments
            .Include(d => d.Building)
            .FirstOrDefaultAsync(d => d.Id == id);
    }
}