using backendInventory.Application.Services.Units.DTO;
using backendInventory.Application.Services.Units.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backendInventory.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UnitController : ControllerBase
{
    private readonly IUnitService _unitService;

    public UnitController(IUnitService unitService)
    {
        _unitService = unitService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUnitAsync([FromBody] UnitDTO unitDTO)
    {
        var unit = await _unitService.CreateUnitAsync(unitDTO);

        return Created("api/Unit/", unit);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllUnitsAsync()
    {
        var units = await _unitService.GetAllUnitsAsync();

        if (!units.Any())
            return NotFound("Units not found.");

        return Ok(units);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetUnitByIdAsync([FromRoute] int id)
    {
        var unit = await _unitService.GetUnitByIdAsync(id);

        if (unit is null)
            return NotFound("Unit not found.");

        return Ok(unit);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUnitAsync([FromBody] UnitDTO unitDTO, [FromRoute] int id)
    {
        var unit = await _unitService.UpdateUnitAsync(unitDTO, id);

        if (unit is null)
            return NotFound("Unit not found.");

        return Ok(unit);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUnitAsync([FromRoute] int id)
    {
        var unit = await _unitService.DeleteUnitAsync(id);

        if (!unit)
            return NotFound("Unit not found.");

        return Ok("Unit deleted.");
    }
}