using AutoMapper;
using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Application.Interfaces.Repositories;
using DGAPrueba.Core.Application.Interfaces.Services;
using DGAPrueba.Core.Domain.Entites;

namespace DGAPrueba.Core.Application.Services;

public class SaleServices : BaseServices<SalesDTO, Sales>, ISalesServices
{
    private readonly ISaleRepository _salesRepository;
    private readonly ISaleProductServices _saleProductServices;

private readonly IMapper _mapper;

    public SaleServices(ISaleRepository salesRepository, IMapper mapper, ISaleProductServices saleProductServices) : base(salesRepository, mapper)
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
        _saleProductServices = saleProductServices;
    }

    public  override async Task<Sales> SaveAsync(SalesDTO saveSalesDTO)
    {
        // Mapear el DTO a la entidad
        var sales = _mapper.Map<Sales>(saveSalesDTO);
        
        // Guardar la entidad en el repositorio
        
        var entitySave = await _salesRepository.SaveAsync(sales);
        
        // verificar si la entidad se guardó correctamente
        if (entitySave == null)
        {
            throw new Exception($"No se pudo guardar el registro");
        }
        
        // Guardar los productos de la venta
        foreach (var saleProduct in saveSalesDTO.Products)
        {
            var saleProductDTO = new SaveSaleProductDTO
            {
                ProductId = saleProduct.ProductId,
                SalesId = entitySave.Id,
                Quantity = saleProduct.Quantity,
                Price = saleProduct.Price,
            };
            
            // Guardar el producto de la venta
            await _saleProductServices.SaveAsync(saleProductDTO);
        }
        return entitySave;
    }
}