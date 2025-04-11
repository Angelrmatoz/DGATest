using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace DGAPrueba.Core.Application.DTOS.Client.Account;

public class SaveUserDTO
{
    [SwaggerParameter("Id del usuario")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Debes ingresar tu Nombre")]
        [SwaggerParameter("Nombre de la persona")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debes Ingresar tu Apellido")]
        [SwaggerParameter("Apellido de la persona")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Debes Ingresar el numero de telefono")]
        [SwaggerParameter("Numero de telefono")]
        public string PhoneNumber { get; set; }

        
        [Required(ErrorMessage = "Debes Ingresar un Usuario")]
        [SwaggerParameter("Nombre de usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debes Ingresar tu Correo")]
        [SwaggerParameter("Correo electronico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [SwaggerParameter("Contraseña")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coiciden")]
        [Required(ErrorMessage = "Debe colocar una contraseña")]
        public string ConfirmPassword { get; set; }

        [JsonIgnore]
        public bool IsConfirm { get; set; }
        [JsonIgnore]
        public bool? HasError { get; set; }
        [JsonIgnore]
        public string? Error { get; set; }
}