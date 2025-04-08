using DGAPrueba.Core.Domain.Common;

namespace DGAPrueba.Core.Domain.Entites;

//Entidad de ventas
public class Sales : BaseEntity 
{
    public DateOnly Date { get; set; }
    public double Total { get; set; }

    // Clave foránea y navegación a Client
    public int ClientId { get; set; }
    public Client Client { get; set; }

    // Navegación para relación muchos-a-muchos con Product
    public List<SaleProduct> SaleProducts { get; set; }
}