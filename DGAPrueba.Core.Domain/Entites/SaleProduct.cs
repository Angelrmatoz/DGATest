using DGAPrueba.Core.Domain.Common;

namespace DGAPrueba.Core.Domain.Entites;

public class SaleProduct : BaseEntity
{
    public int SalesId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    
    //Navegacion
    public Sales Sales { get; set; }
    public Product Product { get; set; }
}