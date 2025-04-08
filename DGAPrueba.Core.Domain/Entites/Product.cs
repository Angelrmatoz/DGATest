using DGAPrueba.Core.Domain.Common;

namespace DGAPrueba.Core.Domain.Entites;
//Entidad de producto

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    
    //navigation property
    public Sales Sales { get; set; }
}