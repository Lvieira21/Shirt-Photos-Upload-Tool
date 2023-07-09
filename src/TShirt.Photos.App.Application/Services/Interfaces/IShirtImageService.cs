namespace TShirt.Photos.App.Application.Services.Interfaces;

using Domain.Entities;
using DTOs;
using Microsoft.AspNetCore.Http;

public interface IShirtImageService
{
    Task<ResultService<List<ShirtImageDTO>>> GetAllByShirtIdAsync(int shirtId);

    Task<ResultService<ShirtImage>> CreateImageAsync(ShirtImageDTO shirtImageDto, IFormFile file);

    Task<ResultService> DeleteAsync(int id, int imageId);
}
