using AutoMapper;
using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Application.Interfaces.Repositories;
using DGAPrueba.Core.Application.Interfaces.Services;
using DGAPrueba.Core.Domain.Entites;

namespace DGAPrueba.Core.Application.Services;

public class SaleServices : BaseServices<SalesDTO, Sales>, ISalesServices
{
    private readonly ISaleRepository _salesRepository;
    private readonly IMapper _mapper;
    
    public SaleServices(ISaleRepository salesRepository, IMapper mapper) : base(salesRepository, mapper)
    {
        _salesRepository = salesRepository;
    }
}