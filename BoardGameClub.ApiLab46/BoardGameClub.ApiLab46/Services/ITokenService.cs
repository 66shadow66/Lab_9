using BoardGameClub.ApiLab46.Models;

namespace BoardGameClub.ApiLab46.Services;

public interface ITokenService
{
    string GenerateToken(Member member);
}