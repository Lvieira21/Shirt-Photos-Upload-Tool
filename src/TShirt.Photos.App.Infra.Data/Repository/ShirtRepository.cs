namespace TShirt.Photos.App.Infra.Data.Repository;

using Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class ShirtRepository : IShirtRepository
{
    private readonly AppDbContext _context;

    public ShirtRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Shirt?> GetByIdAsync(int id)
    {
        return await _context.Shirts
            .Include(shirt => shirt.Colours)
            .Include(shirt => shirt.Fabrics)
            .Include(shirt => shirt.Images)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Shirt>> GetAllAsync()
    {
        return await _context.Shirts
            .OrderBy(shirt => shirt.Id)
            .Include(shirt => shirt.Colours)
            .Include(shirt => shirt.Fabrics)
            .Include(shirt => shirt.Images)
            .ToListAsync();
    }
}
