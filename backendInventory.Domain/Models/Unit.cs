namespace backendInventory.Domain.Models;

public class Unit
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Number { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }

    public ICollection<Building>? Buildings { get; set; }
    public ICollection<Printer>? Printers { get; set; }
}