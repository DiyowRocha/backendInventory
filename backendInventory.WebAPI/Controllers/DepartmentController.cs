using backendInventory.Application.Services.Departments.DTO;
using backendInventory.Application.Services.Departments.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backendInventory.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateDepartmentAsync([FromBody] DepartmentDTO departmentDTO)
    {
        var department = await _departmentService.CreateDepartmentAsync(departmentDTO);

        return Created("api/Department/", department);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllDepartmentsAsync()
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();

        if (!departments.Any())
            return NotFound("Departments not found.");

        return Ok(departments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetDepartmentByIdAsync([FromRoute] int id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);

        if (department is null)
            return NotFound("Department not found.");

        return Ok(department);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDepartmentAsync([FromBody] DepartmentDTO departmentDTO, [FromRoute] int id)
    {
        var department = await _departmentService.UpdateDepartmentAsync(departmentDTO, id);

        if (department is null)
            return NotFound("Department not found.");

        return Ok(department);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDepartmentAsync([FromRoute] int id)
    {
        var department = await _departmentService.DeleteDepartmentAsync(id);

        if (!department)
            return NotFound("Department not found.");

        return Ok("Department deleted.");
    }
}