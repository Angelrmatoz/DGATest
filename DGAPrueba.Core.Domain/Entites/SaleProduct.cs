using DGAPrueba.Core.Domain.Common;

namespace DGAPrueba.Core.Domain.Entites;

public class SaleProduct : BaseEntity
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    
    //relacion de ventas
    public int SalesId { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public Sales Sales { get; set; }    
    
    //relacion de productos
    public int ProductId { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public Product Product { get; set; }
}