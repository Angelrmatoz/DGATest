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
        try
        {
            var result = await _salesServices.GetAllAsync();
            if(result == null)
            {
                return BadRequest("No encontrado");
            }
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }

    [HttpGet("GetById")]
    // GET
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _salesServices.GetByIdAsync(id);
            if(result == null)
            {
                return BadRequest("No encontrado");
            }
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    [HttpPost("Save")]
    // POST
    public async Task<IActionResult> Save([FromBody] SalesDTO sales)
    {
        try
        {
            var result = await _salesServices.SaveAsync(sales);
            if(result == null)
            {
                return BadRequest("No encontrado");
            }
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    // PUT
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] SalesDTO sales)
    {
        try
        {
            var result = await _salesServices.UpdateAsync(sales, sales.Id);
            if(result == null)
            {
                return BadRequest("No encontrado");
            }
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    // DELETE
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _salesServices.DeleteAsync(id);
            if(result == null)
            {
                return BadRequest("No encontrado");
            }
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
}