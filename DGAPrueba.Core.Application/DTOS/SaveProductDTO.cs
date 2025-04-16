using System.ComponentModel.DataAnnotations;

namespace DGAPrueba.Core.Application.DTOS.Client;

public class SaveProductDTO
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [MinLength(length:7)]
    public string Description { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    public double Price { get; set; }
    [Required]
    public int Stock { get; set; }
}