using AutoMapper;
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
}