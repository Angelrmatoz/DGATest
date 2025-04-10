using DGAPrueba.Core.Domain.Common;

namespace DGAPrueba.Core.Domain.Entites;

//Entidad de cliente
public class Client : BaseEntity 
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    // Navegación: Un cliente puede tener múltiples ventas
    [System.Text.Json.Serialization.JsonIgnore]
    public List<Sales> Sales { get; set; }
}