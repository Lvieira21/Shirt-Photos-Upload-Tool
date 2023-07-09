namespace TShirt.Photos.App.Infra.Web.Controllers;

using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TShirt.Photos.App.Application.DTOs;

[ApiController]
[Route("api/shirts/{id:int}/images")]
public class ShirtImagesController : ControllerBase
{
    private readonly IShirtImageService _imageService;

    public ShirtImagesController(IShirtImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ShirtImageDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetShirtImages([FromRoute] int id)
    {
        var result = await _imageService.GetAllByShirtIdAsync(id);

        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }

        return BadRequest(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ShirtImageDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync([FromForm] IFormFile file,
        [FromRoute] int id,
        [FromQuery] int colorId,
        [FromQuery] int fabricId)
    {
        var imageDto = new ShirtImageDTO(null, id, colorId, fabricId);
        var result = await _imageService.CreateImageAsync(imageDto, file);

        if (result.IsSuccess)
        {
            return this.Created($"shirts/{result.Data.ShirtId}/images/{result.Data.Id}", null);
        }

        return this.BadRequest(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ShirtImageDTO), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("{imageId:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromRoute] int imageId)
    {
        var result = await _imageService.DeleteAsync(id, imageId);
        if (result.IsSuccess)
            return NoContent();

        return NotFound();
    }
}
