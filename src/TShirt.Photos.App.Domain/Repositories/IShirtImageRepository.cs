namespace TShirt.Photos.App.Domain.Repositories;

using Entities;

public interface IShirtImageRepository
{
    Task<ICollection<ShirtImage>> GetAllByShirtIdAsync(int shirtId);

    Task<ShirtImage?> GetByShirtIdAndImageIdAsync(int id, int imageId);

    Task<ShirtImage> CreateImageAsync(ShirtImage image);

    Task DeleteAsync(ShirtImage image);
}
