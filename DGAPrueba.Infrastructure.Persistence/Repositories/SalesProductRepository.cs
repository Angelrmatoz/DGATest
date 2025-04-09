using DGAPrueba.Core.Application.Interfaces.Repositories;
using DGAPrueba.Core.Domain.Entites;
using DGAPrueba.Infrastructure.Persistence.Context;

namespace DGAPrueba.Infrastructure.Persistence.Repositories;

public class SalesProductRepository : BaseRepository<SaleProduct>, ISalesProductRepository
{
    private readonly DGAContext _context;
    public SalesProductRepository(DGAContext context) : base(context)
    {
        _context = context;
    }
}