using DGAPrueba.Core.Application.Interfaces.Repositories;
using DGAPrueba.Core.Domain.Entites;
using DGAPrueba.Infrastructure.Persistence.Context;

namespace DGAPrueba.Infrastructure.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly DGAContext _context;
    public ProductRepository(DGAContext context) : base(context)
    {
        _context = context;
    }
}