using AutoMapper;
using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Application.Interfaces.Repositories;
using DGAPrueba.Core.Application.Interfaces.Services;
using DGAPrueba.Core.Domain.Entites;

namespace DGAPrueba.Core.Application.Services;

public class ProductServices : BaseServices<SaveProductDTO, Product>, IProductServices
{
    private readonly IProductRepository _IProductRepository;
    private readonly IMapper _mapper;
    
    public ProductServices(IProductRepository productRepository, IMapper mapper) : base(productRepository, mapper)
    {
        _IProductRepository = productRepository;
    }
}