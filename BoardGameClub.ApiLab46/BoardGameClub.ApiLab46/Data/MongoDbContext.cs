using BoardGameClub.ApiLab46.Models;
using MongoDB.Driver;

namespace BoardGameClub.ApiLab46.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _db;

    public MongoDbContext(IConfiguration config)
    {
        var client = new MongoClient(config.GetSection("MongoDb:ConnectionString").Value);
        _db = client.GetDatabase(config.GetSection("MongoDb:DatabaseName").Value);
    }

    public IMongoCollection<Member> Members => _db.GetCollection<Member>("members");
    public IMongoCollection<Game> Games => _db.GetCollection<Game>("games");
    public IMongoCollection<Session> Sessions => _db.GetCollection<Session>("sessions");
}