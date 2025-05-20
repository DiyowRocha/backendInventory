using backendInventory.Application.Services.Manufacturers.DTO;
using backendInventory.Application.Services.Manufacturers.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backendInventory.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ManufacturerController : ControllerBase
{
    private readonly IManufacturerService _manufacturerService;

    public ManufacturerController(IManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateManufacturerAsync([FromBody] ManufacturerDTO manufacturerDTO)
    {
        var createdManufacturer = await _manufacturerService.CreateManufacturerAsync(manufacturerDTO);

        return Created("/api/Manufacturer/", createdManufacturer);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllManufacturersAsync()
    {
        var manufacturers = await _manufacturerService.GetAllManufacturers();

        if (!manufacturers.Any())
            return NotFound("Manufacturers not found.");

        return Ok(manufacturers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetManufacturerByIdAsync([FromRoute] int id)
    {
        var manufacturer = await _manufacturerService.GetManufacturerByIdAsync(id);

        if (manufacturer is null)
            return NotFound("Manufacturer not found.");

        return Ok(manufacturer);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateManufacturerAsync([FromBody] ManufacturerDTO manufacturerDTO, [FromRoute] int id)
    {
        var manufacturer = await _manufacturerService.UpdateManufacturerAsync(manufacturerDTO, id);

        if (manufacturer is null)
            return NotFound("Manufacturer not found.");

        return Ok(manufacturer);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteManufacturerAsync([FromRoute] int id)
    {
        var manufacturer = await _manufacturerService.DeleteManufacturerAsync(id);

        if (!manufacturer)
            return NotFound("Manufacturer not found.");

        return Ok("Manufacturer deleted.");
    }
}