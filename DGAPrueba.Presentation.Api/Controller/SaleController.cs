using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DGAPrueba.Presentation.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class SaleController : ControllerBase
{
    private readonly ISalesServices _salesServices;
    public SaleController(ISalesServices salesServices)
    {
        _salesServices = salesServices;
    }
    
    [HttpGet("GetAll")]
    // GET
    public async Task<IActionResult> GetAll()
    {
        var result = await _salesServices.GetAllAsync();
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
        var result = await _salesServices.GetByIdAsync(id);
        if(result == null)
        {
            return BadRequest("No encontrado");
        }
        return Ok(result);
    }
    
    [HttpPost("Save")]
    // POST
    public async Task<IActionResult> Save([FromBody] SalesDTO sales)
    {
        var result = await _salesServices.SaveAsync(sales);
        if(result == null)
        {
            return BadRequest("No encontrado");
        }
        return Ok(result);
    }
    
    // PUT
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] SalesDTO sales)
    {
        var result = await _salesServices.UpdateAsync(sales);
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
        var result = await _salesServices.DeleteAsync(id);
        if(result == null)
        {
            return BadRequest("No encontrado");
        }
        return Ok(result);
    }
}