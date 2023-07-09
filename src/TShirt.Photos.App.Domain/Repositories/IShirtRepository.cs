namespace TShirt.Photos.App.Domain.Repositories;

using Entities;

public interface IShirtRepository
{
    Task<Shirt?> GetByIdAsync(int id);

    Task<ICollection<Shirt>> GetAllAsync();
}
