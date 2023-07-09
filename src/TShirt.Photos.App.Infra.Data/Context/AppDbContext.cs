namespace TShirt.Photos.App.Infra.Data.Context;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Shirt> Shirts { get; set; }

    public DbSet<ShirtColour> Colours { get; set; }

    public DbSet<ShirtFabric> Fabrics { get; set; }

    public DbSet<ShirtImage> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shirt>()
            .HasData(
                new Shirt(1, "Abstract"),
                new Shirt(2, "Bubbles"),
                new Shirt(3, "Plain"));

        modelBuilder.Entity<ShirtColour>()
            .HasData(
                new ShirtColour(1, "White"),
                new ShirtColour(2, "Red"),
                new ShirtColour(3, "Grey"));

        modelBuilder.Entity<ShirtFabric>()
            .HasData(
                new ShirtFabric(1, "Cotton"),
                new ShirtFabric(2, "Linen"),
                new ShirtFabric(3, "Silk"));

        modelBuilder.Entity<Shirt>()
            .HasMany(s => s.Colours)
            .WithMany(c => c.Shirts)
            .UsingEntity<Dictionary<string, object>>(
                "ShirtColour",
                r => r.HasOne<ShirtColour>().WithMany().HasForeignKey("ColourId"),
                l => l.HasOne<Shirt>().WithMany().HasForeignKey("ShirtId"),
                je =>
                {
                    je.HasKey("ShirtId", "ColourId");
                    je.HasData(
                        new { ShirtId = 1, ColourId = 1 },
                        new { ShirtId = 1, ColourId = 2 },
                        new { ShirtId = 1, ColourId = 3 },
                        new { ShirtId = 2, ColourId = 2 },
                        new { ShirtId = 2, ColourId = 3 },
                        new { ShirtId = 3, ColourId = 1 });
                });

        modelBuilder.Entity<Shirt>()
            .HasMany(s => s.Fabrics)
            .WithMany(c => c.Shirts)
            .UsingEntity<Dictionary<string, object>>(
                "ShirtFabric",
                r => r.HasOne<ShirtFabric>().WithMany().HasForeignKey("FabricId"),
                l => l.HasOne<Shirt>().WithMany().HasForeignKey("ShirtId"),
                je =>
                {
                    je.HasKey("ShirtId", "FabricId");
                    je.HasData(
                        new { ShirtId = 1, FabricId = 1 },
                        new { ShirtId = 1, FabricId = 2 },
                        new { ShirtId = 1, FabricId = 3 },
                        new { ShirtId = 2, FabricId = 1 },
                        new { ShirtId = 2, FabricId = 2 },
                        new { ShirtId = 3, FabricId = 1 });
                });
    }
}
