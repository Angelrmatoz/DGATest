namespace DGAPrueba.Core.Application.Interfaces.Repositories;

public interface IBaseRepository<T>
{
    //Repositorio generico    
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllWithIncludeAsync(List<string> includes);
    Task<T> GetByIdAsync(int id);
    Task<T> SaveAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
}