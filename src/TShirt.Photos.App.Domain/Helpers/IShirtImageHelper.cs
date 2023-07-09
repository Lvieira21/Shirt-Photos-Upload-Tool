namespace TShirt.Photos.App.Domain.Helpers;

using Microsoft.AspNetCore.Http;

public interface IShirtImageHelper
{
    string SaveFile(IFormFile file);

    void DeleteFile(string path);
}
