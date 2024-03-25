using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games = new()
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

    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? Get(int id)
    {
        return games.Find(game => game.Id == id);
    }

    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
    }
}