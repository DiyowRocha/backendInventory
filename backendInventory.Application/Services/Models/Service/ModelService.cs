using AutoMapper;
using backendInventory.Application.Services.Models.DTO;
using backendInventory.Application.Services.Models.Interface;
using backendInventory.Application.Services.Models.ViewModel;
using backendInventory.Domain.Models;
using backendInventory.Infrastructure.Repository;
using backendInventory.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace backendInventory.Application.Services.Models.Service;

public class ModelService : IModelService
{
    private readonly IModelRepository _modelRepository;
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IMapper _mapper;

    public ModelService(IModelRepository modelRepository, IMapper mapper, IManufacturerRepository manufacturerRepository)
    {
        _modelRepository = modelRepository;
        _manufacturerRepository = manufacturerRepository;
        _mapper = mapper;
    }

    public async Task<ModelViewModel> CreateModelAsync(ModelDTO modelDTO)
    {
        var manufacturer = await _manufacturerRepository.GetById(modelDTO.ManufacturerId);
        if (manufacturer is null)
            return null;

        var model = _mapper.Map<Model>(modelDTO);
        model.Manufacturer = manufacturer;

        await _modelRepository.Add(model);

        return _mapper.Map<ModelViewModel>(model);
    }

    public async Task<IEnumerable<ModelViewModel>> GetAllModelsAsync()
    {
        var models = await _modelRepository.GetAllWithManufacturer();

        return _mapper.Map<IEnumerable<ModelViewModel>>(models);
    }

    public async Task<ModelViewModel> GetModelByIdAsync(int id)
    {
        var model = await _modelRepository.GetByIdWithManufacturer(id);

        return _mapper.Map<ModelViewModel>(model);
    }

    public async Task<ModelViewModel> UpdateModelAsync(ModelDTO modelDTO, int id)
    {
        var model = await _modelRepository.GetByIdWithManufacturer(id);
        if (model is null)
            return null;

        var manufacturer = await _manufacturerRepository.GetById(modelDTO.ManufacturerId);
        if (manufacturer is null)
            throw new Exception("Manufacturer not found.");

        model.Name = modelDTO.Name;
        model.ManufacturerId = modelDTO.ManufacturerId;

        _modelRepository.Update(model);

        return _mapper.Map<ModelViewModel>(model);
    }

    public async Task<bool> DeleteModelAsync(int id)
    {
        var model = await _modelRepository.GetById(id);

        if (model is null)
            return false;

        _modelRepository.Delete(model);

        return true;
    }

}