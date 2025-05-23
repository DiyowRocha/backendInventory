namespace backendInventory.Domain.Models;

public class Printer
{
    public int Id { get; set; }
    // string é nullable por default
    public string? SerialNumber { get; set; }
    public string? IPAddress { get; set; }
    public string? PrintQueue { get; set; }

    public int ManufacturerId { get; set; }
    public Manufacturer? Manufacturer { get; set; }

    public int ModelId { get; set; }
    public Model? Model { get; set; }

    public int UnitId { get; set; }
    public Unit? Unit { get; set; }

    public int BuildingId { get; set; }
    public Building? Building { get; set; }

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
}