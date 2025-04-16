using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DGAPrueba.Presentation.Api.Controller;

[ApiController]
[Authorize]
[Route("api/[controller]")]

public class SaleProductController : ControllerBase
{
    private readonly ISaleProductServices _saleProductServices;
    
    public SaleProductController(ISaleProductServices saleProductServices)
    {
        _saleProductServices = saleProductServices;
    }
    
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // GET
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _saleProductServices.GetAllWithIncludeAsync();
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
            var result = await _saleProductServices.GetByIdAsync(id);
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

    #region Comment

    /*
    [HttpPost("Save")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // POST
    public async Task<IActionResult> Save([FromBody] SaveSaleProductDTO saleProduct)
    {
        try
        {
            // validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _saleProductServices.SaveAsync(saleProduct);
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
    
    // PUT
    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update([FromBody] SaveSaleProductDTO saleProduct)
    {
        try
        {
            // validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _saleProductServices.UpdateAsync(saleProduct, saleProduct.Id);
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
            var result = await _saleProductServices.DeleteAsync(id);
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
    }*/

    #endregion
}