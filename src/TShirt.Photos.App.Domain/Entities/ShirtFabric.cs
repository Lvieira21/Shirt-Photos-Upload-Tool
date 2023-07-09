namespace TShirt.Photos.App.Domain.Entities;

public class ShirtFabric
{
    public int Id { get; private set; }

    public string Type { get; private set; }

    public IReadOnlyList<Shirt> Shirts { get; set; }

    public ShirtFabric(int id, string type)
    {
        Id = id;
        Type = type;
        Shirts = new List<Shirt>();
    }
}
