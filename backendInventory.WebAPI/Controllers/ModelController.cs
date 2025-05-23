using backendInventory.Application.Services.Models.DTO;
using backendInventory.Application.Services.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backendInventory.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModelController : ControllerBase
{
    private readonly IModelService _modelService;

    public ModelController(IModelService modelService)
    {
        _modelService = modelService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateModelAsync([FromBody] ModelDTO modelDTO)
    {
        var model = await _modelService.CreateModelAsync(modelDTO);

        if (model is null)
            return NotFound("Manufacturer not found."); // a mensagem // nome da classe estão estranhos

        return Created("api/model/", model);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllModelsAsync()
    {
        var models = await _modelService.GetAllModelsAsync();

        if (!models.Any())
            return NotFound("Models not found."); // --> Atenção no retorno, para esse caso existe um melhor https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/404 

        return Ok(models);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetModelByIdAsync([FromRoute] int id)
    {
        var model = await _modelService.GetModelByIdAsync(id);

        if (model is null)
            return NotFound("Model not found.");

        return Ok(model);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateModelAsync([FromBody] ModelDTO modelDTO, [FromRoute] int id)
    {
        var model = await _modelService.UpdateModelAsync(modelDTO, id);

        if (model is null)
            return NotFound("Model not found.");

        return Ok(model);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteModelAsync([FromRoute] int id)
    {
        var model = await _modelService.DeleteModelAsync(id);

        if (!model)
            return NotFound("Model not found.");

        return Ok("Model deleted.");
    }
}