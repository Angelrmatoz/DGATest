using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DGAPrueba.Presentation.Api.Controller;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("GetAll")]
    // GET
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            // Get all clients
            var result = await _clientService.GetAllAsync();
            if(result == null)
            {
                return NotFound("No encontrado");
            }
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Error interno del servidor: {e.Message}");
        }
       
    }

    [HttpGet("GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    
    // GET
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            // Get client by id
            var result = await _clientService.GetByIdAsync(id);
            if(result == null)
            {
                return NotFound("No encontrado");
            }
            return Ok(result);
        }
        catch (Exception e) 
        {
            return StatusCode(500, $"Error interno del servidor: {e.Message}");
        }
    }
    
    [HttpPost("Save")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // POST
    public async Task<IActionResult> Save([FromBody] SaveClientDTO client)
    {
        try
        {
            // Validate the model state
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _clientService.SaveAsync(client);
            // Check if the result is null
            if(result.Id == 0)
            {
                return NotFound("No encontrado");
            }
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Error interno del servidor: {e.Message}");
        }  
    }
    
    // PUT
    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update([FromBody] SaveClientDTO client)
    {
        try
        {
            var result = await _clientService.UpdateAsync(client, client.Id);
            if(result == null)
            {
                return NotFound("No encontrado");
            }
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Error interno del servidor: {e.Message}");
        }
    }
    
    // DELETE
    [HttpDelete("Delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _clientService.DeleteAsync(id);
            if(result == null)
            {
                return NotFound("No encontrado");
            }

            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Error interno del servidor: {e.Message}");
        }
    }
    
}