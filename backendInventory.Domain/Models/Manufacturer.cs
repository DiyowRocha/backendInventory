namespace backendInventory.Domain.Models;

public class Manufacturer
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Model>? Models { get; set; }
    public ICollection<Printer>? Printers { get; set; }
}