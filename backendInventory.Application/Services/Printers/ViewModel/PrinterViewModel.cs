namespace backendInventory.Application.Services.Printers.ViewModel;

public class PrinterViewModel
{
    public int Id { get; set; }
    public string? SerialNumber { get; set; }
    public string? ManufacturerName { get; set; }
    public string? ModelName { get; set; }
    public string? UnitName { get; set; }
    public string? BuildingName { get; set; }
    public string? DepartmentName { get; set; }
    public string? DepartmentFloor { get; set; }
    public string? IPAddress { get; set; }
    public string? PrintQueue { get; set; }    
}