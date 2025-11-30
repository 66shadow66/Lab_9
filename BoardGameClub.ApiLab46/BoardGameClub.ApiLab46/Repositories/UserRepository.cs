using BoardGameClub.ApiLab46.Data;
using BoardGameClub.ApiLab46.Models;
using MongoDB.Driver;

namespace BoardGameClub.ApiLab46.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _users;
    public UserRepository(MongoDbContext context) => _users = context.Users;

    public Task<User?> GetByEmailAsync(string email)
        => _users.Find(u => u.Email == email).FirstOrDefaultAsync();

    public Task CreateAsync(User user)
        => _users.InsertOneAsync(user);
}