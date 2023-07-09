namespace TShirt.Photos.App.Application.DTOs;

public record ShirtImageDTO(int? id, int ShirtId, int ColourId, int FabricId)
{
    public string? ImageUrl { get; set; }
}
