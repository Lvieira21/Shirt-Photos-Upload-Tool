namespace TShirt.Photos.App.Infra.Web.Core;

using Microsoft.Extensions.FileProviders;

public static class InitializeStaticFilesDirectory
{
    public static void AddStaticFilesDirectory(this IApplicationBuilder app)
    {
        var solutionDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (solutionDirectory != null && !solutionDirectory.GetFiles("*.sln").Any())
        {
            solutionDirectory = solutionDirectory.Parent;
        }

        if (solutionDirectory is null)
        {
            return;
        }

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(solutionDirectory.FullName, "env/Photos")),
        });
    }
}
