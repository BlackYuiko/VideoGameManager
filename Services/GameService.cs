using System.Collections.Generic;
using VideoGameManager.Models;


namespace VideoGameManager.Services
{
    public class GameService
    {
        private readonly List<Game> _games;

        private int _nextId = 4;

        public GameService()
        {
            _games = new List<Game>
            {
                new() { Id=1, Title="The Legend of Zelda: TotK", Genre="Adventure",
                        Year=2023, Score=9.8, Description="Open-world action RPG" },
                new() { Id=2, Title="Elden Ring", Genre="RPG",
                        Year=2022, Score=9.5, Description="Open-world soulslike" },
                new() { Id=3, Title="Celeste", Genre="Platformer",
                        Year=2018, Score=9.0, Description="Precision platformer" }
            };

        }
        public List<Game> GetAll() => _games;

        public Game? GetById(int id) => _games.FirstOrDefault(g => g.Id == id);

        public void Add(Game game) { game.Id = _nextId++; _games.Add(game); }

        public void Update(Game updatedGame)
        {
            var existingGame = _games.FirstOrDefault(g => g.Id == updatedGame.Id);
            if (existingGame != null)
            {
                existingGame.Title = updatedGame.Title;
                existingGame.Genre = updatedGame.Genre;
                existingGame.Year = updatedGame.Year;
                existingGame.Score = updatedGame.Score;
                existingGame.Description = updatedGame.Description;
            }
        }

        public void Delete(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game != null)
            {
                _games.Remove(game);
            }
        }
    }
}
