using BoardGameClub.ApiLab46.Models;
using BoardGameClub.ApiLab46.Repositories;

namespace BoardGameClub.ApiLab46.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    public UserService(IUserRepository repo) => _repo = repo;

    public Task<User?> GetByEmailAsync(string email) => _repo.GetByEmailAsync(email);

    public async Task CreateAsync(User user)
    {
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        await _repo.CreateAsync(user);
    }
}