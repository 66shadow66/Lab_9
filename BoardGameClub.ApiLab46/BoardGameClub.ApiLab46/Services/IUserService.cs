using BoardGameClub.ApiLab46.Models;

namespace BoardGameClub.ApiLab46.Services;

public interface IUserService
{
    Task<User?> GetByEmailAsync(string email);
    Task CreateAsync(User user);
}