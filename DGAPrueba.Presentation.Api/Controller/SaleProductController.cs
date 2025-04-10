using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DGAPrueba.Presentation.Api.Controller;

[ApiController]
[Route("api/[controller]")]

public class SaleProductController : ControllerBase
{
    private readonly ISaleProductServices _saleProductServices;
    
    public SaleProductController(ISaleProductServices saleProductServices)
    {
        _saleProductServices = saleProductServices;
    }
    
    [HttpGet("GetAll")]
    // GET
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _saleProductServices.GetAllAsync();
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
            var result = await _saleProductServices.GetByIdAsync(id);
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
    public async Task<IActionResult> Save([FromBody] SaveSaleProductDTO saleProduct)
    {
        try
        {
            var result = await _saleProductServices.SaveAsync(saleProduct);
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
    public async Task<IActionResult> Update([FromBody] SaveSaleProductDTO saleProduct)
    {
        try
        {
            var result = await _saleProductServices.UpdateAsync(saleProduct, saleProduct.Id);
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
            var result = await _saleProductServices.DeleteAsync(id);
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