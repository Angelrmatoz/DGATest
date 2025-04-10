using AutoMapper;
using DGAPrueba.Core.Application.Interfaces.Repositories;
using DGAPrueba.Core.Application.Interfaces.Services;

namespace DGAPrueba.Core.Application.Services;

public class BaseServices<SaveDTO, Entity> : IBaseService<SaveDTO, Entity> 
    where Entity : class
    where SaveDTO : class
{
    private readonly IBaseRepository<Entity> _repository;
    private readonly IMapper _mapper;
    public BaseServices(IBaseRepository<Entity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // Este metodo es para guardar un objeto en la base de datos
    public async Task<Entity> SaveAsync(SaveDTO vm)
    {
        
        // guardar el objeto en la base de datos
        Entity entity = await _repository.SaveAsync(_mapper.Map<Entity>(vm));
        // si no se guarda el objeto
        // lanzar una excepcion
        if (entity == null)
        {
            throw new Exception($"No se pudo guardar el registro");
        }
        return entity;
    }

    // Este metodo es para actualizar un objeto en la base de datos
    public async Task<Entity> UpdateAsync(SaveDTO entity, int id)
    {
        // mapear el objeto a la entidad
        var entityUpdate = _mapper.Map<Entity>(entity);
        
        // buscar el objeto en la base de datos 
        // y actualizarlo
        Entity T = await _repository.UpdateAsync(entityUpdate, id);
        
        // si no se encuentra el objeto
        // lanzar una excepcion
        if (T == null)
        {
            throw new Exception($"No se encontro el registro con id {id}");
        }
        return _mapper.Map<Entity>(T);
    }
// Este metodo es para eliminar un objeto en la base de datos
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.DeleteAsync(id);
        if (entity == null)
        {
            throw new Exception($"No se encontro el registro con id {id}");
        }
        return entity;
    }

    // Este metodo es para obtener un objeto por su id
    public async Task<Entity> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new Exception($"No se encontro el registro con id {id}");
        }
        return entity;
    }

    public async Task<List<Entity>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        if (entities == null)
        {
            throw new Exception($"No se encontraron registros");
        }
        return entities;
    }
}