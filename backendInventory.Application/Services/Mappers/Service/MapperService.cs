using AutoMapper;
using AutoMapper.Configuration.Conventions;
using backendInventory.Application.Services.Mappers.Interface;

namespace backendInventory.Application.Services.Mappers.Service;

public class MapperService : IMapperService
{
    private readonly IMapper _mapper;

    public MapperService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        return _mapper.Map<TDestination>(source);
    }
}