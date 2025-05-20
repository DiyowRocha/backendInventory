namespace backendInventory.Infrastructure.Repository.Interface;

public interface IRepository<T> where T : class
{
    Task<T> GetById(int id);
    Task<T?> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}