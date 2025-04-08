namespace DGAPrueba.Core.Application.Interfaces.Services;

public interface IBaseService<Entity> 
    where Entity : class
{
    //Servicio generico
    Task<Entity> SaveAsync(Entity entity);
    Task<Entity> UpdateAsync(Entity entity);
    Task<bool> DeleteAsync(int id);
    Task<Entity> GetByIdAsync(int id);
    Task<List<Entity>> GetAllAsync();
    
}