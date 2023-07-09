namespace TShirt.Photos.App.Infra.Data.Helpers;

using Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

public class ShirtImageHelper : IShirtImageHelper
{
    private readonly string _filePath;

    public ShirtImageHelper()
    {
        var solutionDirectory = new DirectoryInfo(Environment.CurrentDirectory);

        while (solutionDirectory != null && !solutionDirectory.GetFiles("*.sln").Any())
        {
            solutionDirectory = solutionDirectory.Parent;
        }

        _filePath = solutionDirectory?.FullName ?? string.Empty;
    }

    public string SaveFile(IFormFile file)
    {
        if (_filePath.IsNullOrEmpty())
        {
            return _filePath;
        }

        var fileName = file.FileName.ToLowerInvariant();

        var mimeType = fileName.Substring(fileName.LastIndexOf("."), fileName.Length - fileName.LastIndexOf("."));

        var physicalPath = _filePath + "/env/Photos/" + Guid.NewGuid() + mimeType;

        using (var stream = new FileStream(physicalPath, FileMode.Create))
        {
            file.CopyToAsync(stream);
        }

        return physicalPath;
    }

    public void DeleteFile(string path)
    {
        if (!File.Exists(path))
        {
            return;
        }

        File.Delete(path);
    }
}
