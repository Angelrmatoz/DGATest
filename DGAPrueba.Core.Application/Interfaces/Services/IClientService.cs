using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Domain.Entites;

namespace DGAPrueba.Core.Application.Interfaces.Services;

public interface IClientService : IBaseService<SaveClientDTO, Client>
{
    Task<SaveClientDTO?> GetByEmailAsync(string email);
}