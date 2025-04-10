using DGAPrueba.Core.Application.DTOS.Client;
using DGAPrueba.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DGAPrueba.Presentation.Api.Controller;

[ApiController]
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
    // GET
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _productServices.GetAllAsync();
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
            var result = await _productServices.GetByIdAsync(id);
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
    public async Task<IActionResult> Save([FromBody] SaveProductDTO product)
    {
        try
        {
            var result = await _productServices.SaveAsync(product);
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
    public async Task<IActionResult> Update([FromBody] SaveProductDTO product)
    {
        
        try
        {
            var result = await _productServices.UpdateAsync(product, product.Id);
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
            var result = await _productServices.DeleteAsync(id);
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