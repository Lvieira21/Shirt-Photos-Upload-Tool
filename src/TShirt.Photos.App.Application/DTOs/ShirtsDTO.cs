namespace TShirt.Photos.App.Application.DTOs;

public record ShirtsDTO(
    int Id,
    string Name,
    int NumberOfColours,
    int NumberOfFabrics,
    int NumberOfImages);
