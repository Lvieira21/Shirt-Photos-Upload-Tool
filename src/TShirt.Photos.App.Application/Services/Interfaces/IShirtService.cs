namespace TShirt.Photos.App.Application.Services.Interfaces;

using DTOs;

public interface IShirtService
{
    Task<ResultService<List<ShirtsDTO>>> GetAllAsync();

    Task<ResultService<ShirtDTO>> GetByIdAsync(int id);
}
