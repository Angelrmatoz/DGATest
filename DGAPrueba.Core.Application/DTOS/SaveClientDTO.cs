using System.ComponentModel.DataAnnotations;

namespace DGAPrueba.Core.Application.DTOS.Client;

public class SaveClientDTO
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
}