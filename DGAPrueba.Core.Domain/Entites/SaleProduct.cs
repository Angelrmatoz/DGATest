using DGAPrueba.Core.Domain.Common;

namespace DGAPrueba.Core.Domain.Entites;

public class SaleProduct : BaseEntity
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    
    //relacion de ventas
    public int SalesId { get; set; }
    public Sales Sales { get; set; }
    
    //relacion de productos
    public int ProductId { get; set; }
    public Product Product { get; set; }
}