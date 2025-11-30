using BoardGameClub.ApiLab46.Models;

namespace BoardGameClub.ApiLab46.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task CreateAsync(User user);
}