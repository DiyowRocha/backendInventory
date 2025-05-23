namespace backendInventory.Domain.Models;

public class Department
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Floor { get; set; }

    public int BuildingId { get; set; }
    public Building? Building { get; set; }

    public ICollection<Printer>? Printers { get; set; }
}