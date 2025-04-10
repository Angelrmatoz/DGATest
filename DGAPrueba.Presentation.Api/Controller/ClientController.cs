using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DGAPrueba.Presentation.Api.Controller;

[ApiController]
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
    public async Task<IActionResult> GetAll()
    {
        var result = await _clientService.GetAllAsync();
        if(result == null)
        {
            return BadRequest("No encontrado");
        }
        return Ok(result);
    }

    [HttpGet("GetById")]
    // GET
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _clientService.GetByIdAsync(id);
        if(result == null)
        {
            return BadRequest("No encontrado");
        }
        return Ok(result);
    }
    
    [HttpPost("Save")]
    // POST
    public async Task<IActionResult> Save([FromBody] SaveClientDTO client)
    {
        
        var result = await _clientService.SaveAsync(client);
        if(result == null)
        {
            return BadRequest("No encontrado");
        }
        return Ok(result);
    }
    
    // PUT
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] SaveClientDTO client)
    {
        var result = await _clientService.UpdateAsync(client, client.Id);
        if(result == null)
        {
            return BadRequest("No encontrado");
        }
        return Ok(result);
    }
    
    // DELETE
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _clientService.DeleteAsync(id);
        if(result == null)
        {
            return BadRequest("No encontrado");
        }
        return Ok(result);
    }
    
}