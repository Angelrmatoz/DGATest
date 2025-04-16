using System.ComponentModel.DataAnnotations;

namespace DGAPrueba.Core.Application.DTOS.Client;

public class SaveSaleProductDTO
{
    public int Id { get; set; }
    [Required]
    public int SalesId { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

}