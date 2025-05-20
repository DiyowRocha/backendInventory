namespace backendInventory.Domain.Models;

public class Model
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int ManufacturerId { get; set; }
    public Manufacturer? Manufacturer { get; set; }

    public ICollection<Printer>? Printers { get; set; }
}