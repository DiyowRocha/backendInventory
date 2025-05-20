using backendInventory.Application.Services.Buildings.DTO;
using backendInventory.Application.Services.Buildings.Interface;
using backendInventory.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace backendInventory.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuildingController : ControllerBase
{
    private readonly IBuildingService _buildingService;

    public BuildingController(IBuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateBuildingAsync([FromBody] BuildingDTO buildingDTO)
    {
        var building = await _buildingService.CreateBuildingAsync(buildingDTO);

        return Created("api/Building/", building);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllBuildingsAsync()
    {
        var buildings = await _buildingService.GetAllBuildingAsync();

        if (!buildings.Any())
            return NotFound("Buildings not found.");

        return Ok(buildings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetBuildingByIdAsync([FromRoute] int id)
    {
        var building = await _buildingService.GetBuildingById(id);

        if (building is null)
            return NotFound("Building not found.");

        return Ok(building);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBuildingAsync([FromBody] BuildingDTO buildingDTO, [FromRoute] int id)
    {
        var building = await _buildingService.UpdateBuildingAsync(buildingDTO, id);

        if (building is null)
            return NotFound("Building not found.");

        return Ok(building);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBuildingAsync([FromRoute] int id)
    {
        var building = await _buildingService.DeleteBuildingAsync(id);

        if (!building)
            return NotFound("Building not found.");

        return Ok("Building deleted.");
    }
}