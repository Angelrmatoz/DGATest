using DGAPrueba.Core.Application.Interfaces.Repositories;
using DGAPrueba.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DGAPrueba.Infrastructure.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    /// Contexto de la base de datos
    private readonly DGAContext _dgaContext;

    public BaseRepository(DGAContext dgaContext)
    {
        _dgaContext = dgaContext;
    }

    // implementacion de los metodos de la interfaz IBaseRepository

    //Repositorio generico
    
    //Metodo para obtener todos los registros de una tabla
    public async Task<List<T>> GetAllAsync()
    {
        return await _dgaContext.Set<T>().ToListAsync();
    }
        
    //Metodo para obtener todos los registros de una tabla con sus relaciones
    public async Task<List<T>> GetAllWithIncludeAsync(List<string> includes)
    {
        var query = _dgaContext.Set<T>().AsQueryable();
        foreach (string include in includes)
        {
            query = query.Include(include);
        }
        return await query.ToListAsync();
    }

    //Metodo para obtener un registro por su id
    public async Task<T> GetByIdAsync(int id)
    {
       var result = await _dgaContext.Set<T>().FindAsync(id);
       if (result == null)
       {
           throw new Exception($"No se encontro el registro con id {id}");
       }
         return result;
    }

    //Metodo para guardar un registro en la base de datos
    public async Task<T> SaveAsync(T entity)
    {
        _dgaContext.Set<T>().Add(entity);
        
        await _dgaContext.SaveChangesAsync();
        return entity;
    }

    //Metodo para actualizar un registro en la base de datos
    public async Task<T> UpdateAsync(T entity)
    {
        T entry = await _dgaContext.Set<T>().FindAsync(entity);
        _dgaContext.Entry(entry).CurrentValues.SetValues(entity);
        await _dgaContext.SaveChangesAsync();
        return entity;
    }

    //Metodo para eliminar un registro de la base de datos
    public async Task<bool> DeleteAsync(int id)
    {
        _dgaContext.Set<T>().Remove(_dgaContext.Set<T>().Find(id));
        var u = await _dgaContext.SaveChangesAsync();
        if (u > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}