using DGAPrueba.Core.Application.DTOS.Account;
using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Domain.Entites;

namespace DGAPrueba.Core.Application.Interfaces.Services;

public interface ISaleProductServices : IBaseService<SaveSaleProductDTO, SaleProduct>
{
    Task<List<SaleProductDTO>> GetAllWithIncludeAsync();

}