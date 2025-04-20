using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DGAPrueba.Core.Application.DTOS.Client.Account;
using DGAPrueba.Core.application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using sDGAPrueba.Infrastructure.Identity.Model;

namespace sDGAPrueba.Infrastructure.Identity.service;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _config;
    
    public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
    }

    #region Metodos publicos

    // Metodo de autenticacion
    public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
    {
        //crear una respuesta para la autenticacion
        AuthenticationResponse response = new AuthenticationResponse();
        
        // buscar el usuario por email
        var user = await _userManager.FindByEmailAsync(request.email);
        if (user == null)
        {
            // si no existe el usuario
            response.Error = "Usuario no encontrado";
            response.HasError = true;
            return response;
        }
        
        //inicia seccion
        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        
        if (!result)
        {
            response.HasError = true;
            response.Error = "Credenciales incorrectas";
            return response;
        }
        
        //si la autenticacion es correcta
        response.Id = user.Id;
        response.Email = user.Email;
        response.UserName = user.UserName;

        //obtener el token jwt
        JwtSecurityToken token = await GenerateJwtToken(user);

        response.JWToken = new JwtSecurityTokenHandler().WriteToken(token);
        response.ExpiresIn = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["JWTSettings:DurationInMinutes"]));
        return response;
    }
    
    // Metodo de registro
    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        // crear una respuesta para el registro
        RegisterResponse response = new RegisterResponse();
        
        //por defecto no hay error
        response.HasError = false;
        
        //verificar si el email ya existe
        var userEmail = await _userManager.FindByEmailAsync(request.Email);
        if (userEmail != null)
        {
            //si el usuario ya existe
            response.HasError = true;
            response.Message = "El usuario ya existe";
            return response;
        }
        
        // verificar si el usuario ya existe
        var userName = await _userManager.FindByNameAsync(request.UserName);
        if (userName != null)
        {
            //si el usuario ya existe
            response.HasError = true;
            response.Message = "El nombre de usuario ya existe";
            return response;
        }
        
        var user  = new ApplicationUser()
        {
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            name = request.Name,
            lastName = request.LastName,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };
        
        // crear el usuario
        var result = await _userManager.CreateAsync(user, request.Password);
        
        // verificar si el usuario se creo correctamente
        if (!result.Succeeded)
        {
            //si no se creo el usuario
            response.HasError = true;
            response.Message = result.Errors.FirstOrDefault().Description;
            return response;
        }
        
        //si el usuario se creo correctamente
        return response;

    }
    
    //eliminar usuario
    public async Task<Boolean> DeleteUserByIdAsync(int code)
    {
        //buscar el usuario por id
        var user = await _userManager.FindByIdAsync(code.ToString());
        if (user == null)
        {
            throw new Exception($"No se encontro el usuario con id {code}");
        }
        //eliminar el usuario
        await _userManager.DeleteAsync(user);
        
        //si el usuario se elimino correctamente
        //retornar el resultado
        return true;
    }
    
    //cerrar session
    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }
    //Obtener todos los usuarios
    public Task<List<SaveUserDTO>> GetAllAsync()
    {
        //obtener todos los usuarios
        var users = _userManager.Users.ToList();
        //mapear los usuarios a la lista de SaveUserDTO
        var usersDTO = users.Select(x => new SaveUserDTO()
        {
            Id = x.Id,
            Username = x.UserName,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
            Name = x.name,
            LastName = x.lastName,
            
        }).ToList();
        //retornar la lista de usuarios
        return Task.FromResult(usersDTO);
    }

    #endregion

    #region metodos privados

    //metodo para generar jwt
    private async Task<JwtSecurityToken> GenerateJwtToken(ApplicationUser user)
    {
        // crear claims
        //para el token
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email.ToString()),
        };
        
        //obtener la clave secreta
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:SecretKey"]!));
        //crear las credenciales
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        
        //crear el token
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["JWTSettings:DurationInMinutes"])),
            signingCredentials: credentials,
            issuer: _config["JWTSettings:Issuer"],
            audience: _config["JWTSettings:Audience"]
        );
        return token;
    } 
    
    #endregion
}