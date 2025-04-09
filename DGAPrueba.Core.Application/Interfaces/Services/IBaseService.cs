namespace DGAPrueba.Core.Application.Interfaces.Services;

public interface IBaseService<DTO, Entity> 
    where Entity : class
    where DTO : class
{
    //Servicio generico
    Task<Entity> SaveAsync(DTO entity);
    Task<Entity> UpdateAsync(DTO entity);
    Task<bool> DeleteAsync(int id);
    Task<Entity> GetByIdAsync(int id);
    Task<List<Entity>> GetAllAsync();
    
}