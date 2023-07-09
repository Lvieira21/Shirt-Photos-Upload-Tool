namespace TShirt.Photos.App.Domain.Entities;

public class ShirtImage
{
    public int Id { get; set; }

    public string Url { get; private set; }

    public int ShirtId { get; private set; }

    public int ColourId { get; private set; }

    public int FabricId { get; private set; }

    public ShirtImage(string? url, int shirtId, int colourId, int fabricId)
    {
        Url = url ?? string.Empty;
        ShirtId = shirtId;
        ColourId = colourId;
        FabricId = fabricId;
    }
}
