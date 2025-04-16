using DGAPrueba.Core.Application.Interfaces.Repositories;
using DGAPrueba.Core.Domain.Entites;
using DGAPrueba.Infrastructure.Persistence.Context;

namespace DGAPrueba.Infrastructure.Persistence.Repositories;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    private readonly DGAContext _context;
    public ClientRepository(DGAContext context) : base(context)
    {
        _context = context;
    }
}