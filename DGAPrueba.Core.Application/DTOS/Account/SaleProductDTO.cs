using DGAPrueba.Core.Domain.Entites;
namespace DGAPrueba.Core.Application.DTOS.Account;

public class SaleProductDTO
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public Product Product { get; set; }
    public Sales Sales { get; set; }
}