using BoardGameClub.ApiLab46.Models;
using BoardGameClub.ApiLab46.Repositories;

namespace BoardGameClub.ApiLab46.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _repo;

    public MemberService(IMemberRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Member>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Member?> GetByIdAsync(string id) => _repo.GetByIdAsync(id);
    public Task<Member?> GetByEmailAsync(string email) => _repo.GetByEmailAsync(email);

    public async Task CreateAsync(Member member)
    {
        member.PasswordHash = BCrypt.Net.BCrypt.HashPassword(member.PasswordHash);
        await _repo.CreateAsync(member);
    }

    public async Task UpdateAsync(string id, Member member)
    {
        member.Id = id;
        if (!string.IsNullOrEmpty(member.PasswordHash))
            member.PasswordHash = BCrypt.Net.BCrypt.HashPassword(member.PasswordHash);
        await _repo.UpdateAsync(id, member);
    }

    public Task DeleteAsync(string id) => _repo.DeleteAsync(id);
}