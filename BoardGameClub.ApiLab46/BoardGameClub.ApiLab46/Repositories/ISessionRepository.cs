using BoardGameClub.ApiLab46.Models;

namespace BoardGameClub.ApiLab46.Repositories;

public interface ISessionRepository
{
    Task<List<Session>> GetAllAsync();
    Task<Session?> GetByIdAsync(string id);
    Task CreateAsync(Session session);
    Task UpdateAsync(string id, Session session);
    Task DeleteAsync(string id);
}