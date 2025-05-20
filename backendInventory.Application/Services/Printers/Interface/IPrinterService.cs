using backendInventory.Application.Services.Printers.DTO;
using backendInventory.Application.Services.Printers.ViewModel;

namespace backendInventory.Application.Services.Printers.Interface;

public interface IPrinterService
{
    Task<PrinterViewModel> CreatePrinterAsync(PrinterDTO printerDTO);
    Task<IEnumerable<PrinterViewModel>> GetAllPrintersAsync();
    Task<PrinterViewModel> GetPrinterByIdAsync(int id);
    Task<PrinterViewModel> UpdatePrinterAsync(PrinterDTO printerDTO, int id);
    Task<bool> DeletePrinterAsync(int id);
}