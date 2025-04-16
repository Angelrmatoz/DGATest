using AutoMapper;
using DGAPrueba.Core.Application.DTOS.Account;
using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Application.Interfaces.Repositories;
using DGAPrueba.Core.Application.Interfaces.Services;
using DGAPrueba.Core.Domain.Entites;

namespace DGAPrueba.Core.Application.Services;

public class SaleProductServices : BaseServices<SaveSaleProductDTO, SaleProduct>, ISaleProductServices
{
    private readonly ISalesProductRepository _salesProductRepository;
    private readonly IMapper _mapper;

    public SaleProductServices(ISalesProductRepository salesProductRepository, IMapper mapper) : base(salesProductRepository, mapper)
    {
        _salesProductRepository = salesProductRepository;
    }
    
    //metodo sobreescrito get con include
    public  async Task<List<SaleProductDTO>> GetAllWithIncludeAsync()
    {
        // Obtener todos los productos de la base de datos
        var propierties = await _salesProductRepository.GetAllWithIncludeAsync(new List<string>{"Sales", "Product"});
        // Mapear la lista de entidades a una lista de DTOs
        return propierties.Select(p => new SaleProductDTO
        {
            ID = p.Id,
            Quantity = p.Quantity,
            Product = p.Product,
            Sales = p.Sales,
        }).ToList();
    }
}