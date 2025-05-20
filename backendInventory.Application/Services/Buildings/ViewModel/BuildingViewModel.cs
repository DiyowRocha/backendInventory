using backendInventory.Domain.Enums;

namespace backendInventory.Application.Services.Buildings.ViewModel;

public class BuildingViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string FloorName { get; set; } = string.Empty;
    public string? UnitName { get; set; }
}