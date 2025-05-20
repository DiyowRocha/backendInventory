using backendInventory.Application.Services.Departments.DTO;
using backendInventory.Application.Services.Departments.ViewModel;

namespace backendInventory.Application.Services.Departments.Interface;

public interface IDepartmentService
{
    Task<DepartmentViewModel> CreateDepartmentAsync(DepartmentDTO departmentDTO);
    Task<IEnumerable<DepartmentViewModel>> GetAllDepartmentsAsync();
    Task<DepartmentViewModel> GetDepartmentByIdAsync(int id);
    Task<DepartmentViewModel> UpdateDepartmentAsync(DepartmentDTO departmentDTO, int id);
    Task<bool> DeleteDepartmentAsync(int id);
}