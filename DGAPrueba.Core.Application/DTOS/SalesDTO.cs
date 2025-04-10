namespace DGAPrueba.Core.Application.DTOS.Client;

public class SalesDTO
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public double Total { get; set; }
    public int ClientId { get; set; }
    public List<SaveSaleProductDTO> Products { get; set; } = new();
}