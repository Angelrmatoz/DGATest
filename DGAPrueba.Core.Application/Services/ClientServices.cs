using AutoMapper;
using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Application.Interfaces.Repositories;
using DGAPrueba.Core.Application.Interfaces.Services;
using DGAPrueba.Core.Domain.Entites;

namespace DGAPrueba.Core.Application.Services;

public class ClientServices : BaseServices<SaveClientDTO, Client>, IClientService
{
    private IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    
    public ClientServices(IClientRepository clientRepository, IMapper mapper) : base(clientRepository, mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<SaveClientDTO?> GetByEmailAsync(string email)
    {
        var allClients = await _clientRepository.GetAllAsync();
        var client = allClients.FirstOrDefault(c => c.Email == email);
        if (client == null) return null;
        return _mapper.Map<SaveClientDTO>(client);
    }
}