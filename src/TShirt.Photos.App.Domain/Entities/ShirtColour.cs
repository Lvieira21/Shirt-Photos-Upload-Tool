namespace TShirt.Photos.App.Domain.Entities;

public class ShirtColour
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public IReadOnlyList<Shirt> Shirts { get; set; }

    public ShirtColour(int id, string name)
    {
        Id = id;
        Name = name;
        Shirts = new List<Shirt>();
    }
}
