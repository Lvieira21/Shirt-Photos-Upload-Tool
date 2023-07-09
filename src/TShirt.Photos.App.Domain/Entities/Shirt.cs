namespace TShirt.Photos.App.Domain.Entities;

public class Shirt
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public IReadOnlyList<ShirtColour> Colours { get; set; }

    public IReadOnlyList<ShirtFabric> Fabrics { get; set; }

    public IReadOnlyList<ShirtImage> Images { get; set; }

    public Shirt(int id, string name)
    {
        Id = id;
        Name = name;
        Colours = new List<ShirtColour>();
        Fabrics = new List<ShirtFabric>();
        Images = new List<ShirtImage>();
    }
}
