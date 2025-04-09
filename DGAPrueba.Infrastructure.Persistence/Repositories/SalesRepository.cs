using DGAPrueba.Core.Application.Interfaces.Repositories;
using DGAPrueba.Core.Domain.Entites;
using DGAPrueba.Infrastructure.Persistence.Context;

namespace DGAPrueba.Infrastructure.Persistence.Repositories;

public class SalesRepository : BaseRepository<Sales>, ISaleRepository
{
    private readonly DGAContext _context;
    public SalesRepository(DGAContext context) : base(context)
    {
        _context = context;
    }
}