using BoardGameClub.ApiLab46.Models;

namespace BoardGameClub.ApiLab46.Repositories;

public interface IGameRepository
{
    Task<List<Game>> GetAllAsync();
    Task<Game?> GetByIdAsync(string id);
    Task CreateAsync(Game game);
    Task UpdateAsync(string id, Game game);
    Task DeleteAsync(string id);
}