using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace backendInventory.Infrastructure.Repository.Service;

public class PrinterRepository : Repository<Printer>, IPrinterRepository
{
    public PrinterRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Printer>> GetAllWithAllRelations()
    {
        return await _context.Printers
            .Include(p => p.Manufacturer)
            .Include(p => p.Model)
            .Include(p => p.Unit)
            .Include(p => p.Building)
            .Include(p => p.Department)
            .ToListAsync();
    }

    public async Task<Printer?> GetByIdWithAllRelations(int id)
    {
        return await _context.Printers
            .Include(p => p.Manufacturer)
            .Include(p => p.Model)
            .Include(p => p.Unit)
            .Include(p => p.Building)
            .Include(p => p.Department)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}