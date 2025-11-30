using BoardGameClub.ApiLab46.Models;

namespace BoardGameClub.ApiLab46.Services;

public interface IMemberService
{
    Task<List<Member>> GetAllAsync();
    Task<Member?> GetByIdAsync(string id);
    Task<Member?> GetByEmailAsync(string email);
    Task CreateAsync(Member member);
    Task UpdateAsync(string id, Member member);
    Task DeleteAsync(string id);
}