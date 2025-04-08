using DGAPrueba.Core.Domain.Common;

namespace DGAPrueba.Core.Domain.Entites;
//Entidad de producto

public class Product : BaseEntity 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    // Navegación: Un producto puede estar en múltiples ventas (relación muchos-a-muchos)
    public List<SaleProduct> SaleProducts { get; set; } = new List<SaleProduct>();
}