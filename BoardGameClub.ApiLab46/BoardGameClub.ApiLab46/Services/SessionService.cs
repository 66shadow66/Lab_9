using BoardGameClub.ApiLab46.Models;
using BoardGameClub.ApiLab46.Repositories;

namespace BoardGameClub.ApiLab46.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _repo;

    public SessionService(ISessionRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Session>> GetAllAsync() => _repo.GetAllAsync();

    public Task<Session?> GetByIdAsync(string id) => _repo.GetByIdAsync(id);

    public Task CreateAsync(Session session) => _repo.CreateAsync(session);

    public async Task UpdateAsync(string id, Session session)
    {
        session.Id = id;
        await _repo.UpdateAsync(id, session);
    }

    public Task DeleteAsync(string id) => _repo.DeleteAsync(id);
}