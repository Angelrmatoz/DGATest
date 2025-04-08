using DGAPrueba.Core.Domain.Common;

namespace DGAPrueba.Core.Domain.Entites;

//Entidad de ventas
public class Sales : BaseEntity
{
    public DateOnly Date { get; set; }
    public int Cliente { get; set; }
    public List<Product> ProductsList { get; set; }
    public double Total { get; set; }
}