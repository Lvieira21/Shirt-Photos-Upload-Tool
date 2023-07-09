namespace TShirt.Photos.App.Infra.Data.Repository;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TShirt.Photos.App.Domain.Repositories;
using TShirt.Photos.App.Infra.Data.Context;

public class ShirtImageRepository : IShirtImageRepository
{
    private readonly AppDbContext _context;

    public ShirtImageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<ShirtImage>> GetAllByShirtIdAsync(int shirtId)
    {
        return await _context.Images
            .Where(image => image.ShirtId == shirtId)
            .ToListAsync();
    }

    public async Task<ShirtImage?> GetByShirtIdAndImageIdAsync(int id, int imageId)
    {
        return await _context.Images.FirstOrDefaultAsync(image => image.ShirtId == id && image.Id == imageId);
    }

    public async Task DeleteAsync(ShirtImage image)
    {
        _context.Remove(image);
        await _context.SaveChangesAsync();
    }

    public async Task<ShirtImage> CreateImageAsync(ShirtImage image)
    {
        _context.Add(image);
        await _context.SaveChangesAsync();
        return image;
    }
}
