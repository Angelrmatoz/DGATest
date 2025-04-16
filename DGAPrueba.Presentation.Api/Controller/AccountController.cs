using DGAPrueba.Core.Application.DTOS.Client.Account;
using DGAPrueba.Core.application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DGAPrueba.Presentation.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    // Injeccion de dependencias
    private readonly IAccountService _accountService;
    
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
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
        return Ok(result);
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
        return Ok(result);
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