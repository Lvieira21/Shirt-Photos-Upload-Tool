namespace TShirt.Photos.App.Infra.Web.Controllers;

using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/shirts")]
public class ShirtController : ControllerBase
{
    private readonly IShirtService _shirtService;

    public ShirtController(IShirtService shirtService)
    {
        _shirtService = shirtService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ShirtsDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _shirtService.GetAllAsync();

        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }

        return BadRequest(result);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(ShirtDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetAsync([FromRoute]int id)
    {
        var result = await _shirtService.GetByIdAsync(id);

        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }

        return BadRequest(result);
    }
}
