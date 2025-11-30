using BoardGameClub.ApiLab46.Models;

namespace BoardGameClub.ApiLab46.Repositories;

public interface IMemberRepository
{
    Task<List<Member>> GetAllAsync();
    Task<Member?> GetByIdAsync(string id);
    Task<Member?> GetByEmailAsync(string email);   // для логіну
    Task CreateAsync(Member member);
    Task UpdateAsync(string id, Member member);
    Task DeleteAsync(string id);
}