using backendInventory.Domain.Enums;

namespace backendInventory.Application.Services.Buildings.DTO;

public class BuildingDTO
{
    public string? Name { get; set; }
    public Floor Floor { get; set; }
    public int UnitId { get; set; }
}