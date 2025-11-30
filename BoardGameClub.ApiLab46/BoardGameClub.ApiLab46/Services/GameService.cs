using BoardGameClub.ApiLab46.Models;
using BoardGameClub.ApiLab46.Repositories;

namespace BoardGameClub.ApiLab46.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _repo;

    public GameService(IGameRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Game>> GetAllAsync() => _repo.GetAllAsync();

    public Task<Game?> GetByIdAsync(string id) => _repo.GetByIdAsync(id);

    public Task CreateAsync(Game game) => _repo.CreateAsync(game);

    public async Task UpdateAsync(string id, Game game)
    {
        game.Id = id;
        await _repo.UpdateAsync(id, game);
    }

    public Task DeleteAsync(string id) => _repo.DeleteAsync(id);
}