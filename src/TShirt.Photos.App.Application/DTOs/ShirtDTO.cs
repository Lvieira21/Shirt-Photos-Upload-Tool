namespace TShirt.Photos.App.Application.DTOs;

public record ShirtDTO(int Id, string Name)
{
    public IReadOnlyList<ShirtColourDTO> Colours { get; set; } = new List<ShirtColourDTO>();

    public IReadOnlyList<ShirtFabricDTO> Fabrics { get; set; } = new List<ShirtFabricDTO>();

    public IReadOnlyList<ShirtImageDTO> Images { get; set; } = new List<ShirtImageDTO>();
}
