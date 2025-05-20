namespace backendInventory.Application.Services.Printers.DTO;

public class PrinterDTO
{
    public string? SerialNumber { get; set; }
    public string? IPAddress { get; set; }
    public string? PrintQueue { get; set; }

    public int ManufacturerId { get; set; }
    public int ModelId { get; set; }
    public int UnitId { get; set; }
    public int BuildingId { get; set; }
    public int DepartmentId { get; set; }
}