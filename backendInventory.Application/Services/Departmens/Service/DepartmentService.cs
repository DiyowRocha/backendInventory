using AutoMapper;
using backendInventory.Application.Services.Departments.DTO;
using backendInventory.Application.Services.Departments.Interface;
using backendInventory.Application.Services.Departments.ViewModel;
using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Repository.Interface;

namespace backendInventory.Application.Services.Departments.Service;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IBuildingRepository _buildingRepository;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentRepository departmentRepository, IBuildingRepository buildingRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _buildingRepository = buildingRepository;
        _mapper = mapper;
    }

    public async Task<DepartmentViewModel> CreateDepartmentAsync(DepartmentDTO departmentDTO)
    {
        var building = await _buildingRepository.GetById(departmentDTO.BuildingId);
        if (building is null)
            throw new Exception("Building not found.");

        var department = _mapper.Map<Department>(departmentDTO);
        await _departmentRepository.Add(department);

        return _mapper.Map<DepartmentViewModel>(department);
    }

    public async Task<IEnumerable<DepartmentViewModel>> GetAllDepartmentsAsync()
    {
        var departments = await _departmentRepository.GetAllWithBuilding();

        return _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
    }

    public async Task<DepartmentViewModel> GetDepartmentByIdAsync(int id)
    {
        var department = await _departmentRepository.GetByIdWithBuilding(id);

        if (department is null)
            return null;

        return _mapper.Map<DepartmentViewModel>(department);
    }

    public async Task<DepartmentViewModel> UpdateDepartmentAsync(DepartmentDTO departmentDTO, int id)
    {
        var department = await _departmentRepository.GetById(id);
        if (department is null)
            return null;

        var building = await _buildingRepository.GetById(departmentDTO.BuildingId);
        if (building is null)
            throw new Exception("Building not found.");

        department.Name = departmentDTO.Name;
        department.BuildingId = departmentDTO.BuildingId;

        _departmentRepository.Update(department);
        return _mapper.Map<DepartmentViewModel>(department);
    }

    public async Task<bool> DeleteDepartmentAsync(int id)
    {
        var department = await _departmentRepository.GetById(id);

        if (department is null)
            return false;

        _departmentRepository.Delete(department);

        return true;
    }
}