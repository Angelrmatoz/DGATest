using System.ComponentModel.DataAnnotations;

namespace DGAPrueba.Core.Application.DTOS.Client;

public class SalesDTO
{
    public int Id { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    [Required]
    public double Total { get; set; }
    [Required]
    public int ClientId { get; set; }
    public List<SaveSaleProductDTO> Products { get; set; } = new();
}