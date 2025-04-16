using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DGAPrueba.Presentation.Api.Controller;

[ApiController]
[Authorize]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private readonly IProductServices _productServices;

    //Injeccion de dependencias
    public ProductController(IProductServices productServices)
    {
        _productServices = productServices;
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
            var result = await _productServices.GetAllAsync();
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
            var result = await _productServices.GetByIdAsync(id);
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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // POST
    public async Task<IActionResult> Save([FromBody] SaveProductDTO product)
    {
        try
        {
            //Validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest("El modelo no es valido");
            }
            var result = await _productServices.SaveAsync(product);
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
    public async Task<IActionResult> Update([FromBody] SaveProductDTO product)
    {
        
        try
        {
            //Validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest("El modelo no es valido");
            }
            var result = await _productServices.UpdateAsync(product, product.Id);
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
            var result = await _productServices.DeleteAsync(id);
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