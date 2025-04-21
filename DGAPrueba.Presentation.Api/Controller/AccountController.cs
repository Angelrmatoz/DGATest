using DGAPrueba.Core.Application.DTOS.Client.Account;
using DGAPrueba.Core.application.Interfaces.Services;
using DGAPrueba.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DGAPrueba.Presentation.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    // Injeccion de dependencias
    private readonly IAccountService _accountService;
    private readonly IClientService _clientService;
    
    public AccountController(IAccountService accountService, IClientService clientService)
    {
        _accountService = accountService;
        _clientService = clientService;
    }
    
    //Login
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] AuthenticationRequest request)
    {
        // Validate the request
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        //autenticar
        var result = await _accountService.AuthenticateAsync(request);
        if (result.HasError)
        {
            return NotFound(result.Error);
        }
        // Buscar el cliente por email
        var client = await _clientService.GetByEmailAsync(result.Email);
        var response = new {
            result.Id,
            result.UserName,
            result.Email,
            result.IsVerified,
            result.HasError,
            result.Error,
            result.JWToken,
            result.ExpiresIn,
            ClientId = client?.Id
        };
        return Ok(response);
    }
    
    //Register
    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        // Validate the request
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        //Registrar
        var result = await _accountService.RegisterAsync(request);
        if (result == null)
        {
            return NotFound("Error al registrar");
        }
        // Crear el cliente asociado
        var client = await _clientService.GetByEmailAsync(request.Email);
        if (client == null)
        {
            var newClient = new DGAPrueba.Core.Application.DTOS.Client.SaveClientDTO
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.PhoneNumber
            };
            await _clientService.SaveAsync(newClient);
            client = await _clientService.GetByEmailAsync(request.Email);
        }
        var response = new {
            result.HasError,
            result.Message,
            ClientId = client?.Id
        };
        return Ok(response);
    }
    
    //delte user
    [HttpDelete("DeleteUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            //Delete user
            var result = await _accountService.DeleteUserByIdAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    
    //Get user
    [HttpGet("GetUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    
    public async Task<IActionResult> GetUser()
    {
        var result = new List<SaveUserDTO>();
        try
        {
            //Get user
             result = await _accountService.GetAllAsync();
            if (result == null)
            {
                return NotFound("Error al obtener el usuario");
            }
        }
        catch (Exception e)
        {
            //Error interno del servidor
            return StatusCode(500, $"Error interno del servidor: {e.Message}");
        }
        
        return Ok(result);
    }

}