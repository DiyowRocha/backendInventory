namespace backendInventory.Application.Services.Mappers.Interface;

public interface IMapperService
{
    TDestination Map<TSource, TDestination>(TSource source);
}