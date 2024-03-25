using GameStore.Api.Entities;

const string GetGameEndpointName = "GetGame";

List<Game> games = new()
{
    new Game()
    {
        Id = 1,
        Name = "Elden Ring",
        Genre = "RPG",
        Price = 59.99M,
        ReleaseDate = new DateTime(2022, 02, 25),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = 2,
        Name = "Dark Souls 3",
        Genre = "RPG",
        Price = 59.99M,
        ReleaseDate = new DateTime(2016, 03, 24),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = 3,
        Name = "Final Fantasy XVI",
        Genre = "RPG",
        Price = 69.99M,
        ReleaseDate = new DateTime(2023, 06, 22),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = 4,
        Name = "Helldivers 2",
        Genre = "Shooter",
        Price = 39.99M,
        ReleaseDate = new DateTime(2024, 02, 8),
        ImageUri = "https://placehold.co/100"
    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/games", () => games);
app.Map("/games/{id}", (int id) =>
{
    Game? game = games.Find(game => game.Id == id);

    if (game is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(game);
})
.WithName(GetGameEndpointName);

app.MapPost("/games", (Game game) =>
{
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

app.MapPut("/games/{id}", (int id, Game updatedGame) =>
{
    Game? existingGame = games.Find(game => game.Id == id);

    if (existingGame is null)
    {
        return Results.NotFound();
    }

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.ImageUri = updatedGame.ImageUri;

    return Results.NoContent();
});

app.Run();
