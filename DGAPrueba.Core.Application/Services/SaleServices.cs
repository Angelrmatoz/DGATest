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
    private readonly IProductRepository _productRepository;
    private readonly IClientRepository _clientRepository;

private readonly IMapper _mapper;

    public SaleServices(ISaleRepository salesRepository, IMapper mapper, ISaleProductServices saleProductServices, IProductRepository productRepository, IClientRepository clientRepository) : base(salesRepository, mapper)
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
        _saleProductServices = saleProductServices;
        _productRepository = productRepository;
        _clientRepository = clientRepository;
    }

    public  override async Task<Sales> SaveAsync(SalesDTO saveSalesDTO)
    {
        // Mapear el DTO a la entidad
        var sales = _mapper.Map<Sales>(saveSalesDTO);

        //validar client 
        var clientList = await _clientRepository.GetAllAsync();
        
        var client = clientList.Find(x => x.Id == saveSalesDTO.ClientId);

        if (client == null)
        {
            throw new Exception("No se ha encontrado el cliente");
        }
        
        //validar productos
        var productList = await _productRepository.GetAllAsync();

        foreach (var product in saveSalesDTO.Products)
        {
            var productListFind = productList.Find(x => x.Id == product.ProductId);
            if (productListFind == null)
            {
                throw new Exception($"No se ha encontrado el producto con id {product.ProductId}");
            }
            
            // Validar stock
            if (productListFind.Stock < product.Quantity)
            {
                throw new Exception($"No hay suficiente stock para el producto con id {product.ProductId}");
            }
        }        
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
            await updateProductStock(saleProduct.ProductId, saleProduct.Quantity);
        }
        
        return entitySave;
    }
    
    private async Task updateProductStock(int id, int quantity)
    {
        // Obtener el producto por id
        var product = await _productRepository.GetByIdAsync(id);
        
        // Verificar si el producto existe
        if (product == null)
        {
            throw new Exception($"No se encontro el producto con id {id}");
        }
        
        // Actualizar el stock del producto
        // restando la cantidad vendida
        product.Stock -= quantity;
        
        // Guardar el producto actualizado
        var updatedProduct = await _productRepository.UpdateAsync(product, id);
    }
}