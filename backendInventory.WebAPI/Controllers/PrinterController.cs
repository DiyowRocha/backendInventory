using backendInventory.Application.Services.Printers.DTO;
using backendInventory.Application.Services.Printers.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backendInventory.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrinterController : ControllerBase
{
    private readonly IPrinterService _printerService;

    public PrinterController(IPrinterService printerService)
    {
        _printerService = printerService;
    }

    [HttpPost]
    public async Task<ActionResult> CreatePrinterAsync([FromBody] PrinterDTO printerDTO)
    {
        var printer = await _printerService.CreatePrinterAsync(printerDTO);

        return Created("api/Printer", printer);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllPrintersAsync()
    {
        var printers = await _printerService.GetAllPrintersAsync();

        if (!printers.Any())
            return NotFound("Printers not found"); // --> Atenção no retorno, para esse caso existe um melhor https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/404 

        return Ok(printers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetPrinterByIdAsync([FromRoute] int id)
    {
        var printer = await _printerService.GetPrinterByIdAsync(id);

        if (printer is null)
            return NotFound("Printer not found");

        return Ok(printer);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePrinterAsync([FromBody] PrinterDTO printerDTO, [FromRoute] int id)
    {
        var printer = await _printerService.UpdatePrinterAsync(printerDTO, id);

        if (printer is null)
            return NotFound("Printer not found.");

        return Ok(printer);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePrinterAsync([FromRoute] int id)
    {
        var printer = await _printerService.DeletePrinterAsync(id);

        if (!printer)
            return NotFound("Printer not found.");

        return Ok("Printer deleted");
    }
}