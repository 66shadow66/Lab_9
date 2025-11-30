using BoardGameClub.ApiLab46.Data;
using BoardGameClub.ApiLab46.Models;
using MongoDB.Driver;

namespace BoardGameClub.ApiLab46.Repositories;

public class GameRepository : IGameRepository
{
    private readonly IMongoCollection<Game> _games;

    public GameRepository(MongoDbContext context)
    {
        _games = context.Games;
    }

    public async Task<List<Game>> GetAllAsync() => await _games.Find(_ => true).ToListAsync();
    public async Task<Game?> GetByIdAsync(string id) => await _games.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task CreateAsync(Game game) => await _games.InsertOneAsync(game);
    public async Task UpdateAsync(string id, Game game) => await _games.ReplaceOneAsync(x => x.Id == id, game);
    public async Task DeleteAsync(string id) => await _games.DeleteOneAsync(x => x.Id == id);
}