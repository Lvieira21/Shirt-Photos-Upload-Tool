# Clean Architecture API
This project was made using principles of Clean Architecture, as well as a few patterns (Repository, unit of work and services).
It uses EF Core with SQL server with a code-first approach.
Since this a more distributed pattern it is needed to specify the project and the startup project in order to update database and/or add migrations:
i.e.: `dotnet ef database update --project src/TShirt.Photos.App.Infra.Data  --startup-project src/TShirt.Photos.App.Infra.Web`

The UI is pretty much simple, is a HTML with JS and it uses `fetch` to access the API/
