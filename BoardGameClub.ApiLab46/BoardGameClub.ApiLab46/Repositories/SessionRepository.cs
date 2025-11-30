using BoardGameClub.ApiLab46.Data;
using BoardGameClub.ApiLab46.Models;
using MongoDB.Driver;

namespace BoardGameClub.ApiLab46.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly IMongoCollection<Session> _sessions;

    public SessionRepository(MongoDbContext context)
    {
        _sessions = context.Sessions;
    }

    public async Task<List<Session>> GetAllAsync()
        => await _sessions.Find(_ => true).ToListAsync();

    public async Task<Session?> GetByIdAsync(string id)
        => await _sessions.Find(s => s.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Session session)
        => await _sessions.InsertOneAsync(session);

    public async Task UpdateAsync(string id, Session session)
        => await _sessions.ReplaceOneAsync(s => s.Id == id, session);

    public async Task DeleteAsync(string id)
        => await _sessions.DeleteOneAsync(s => s.Id == id);
}