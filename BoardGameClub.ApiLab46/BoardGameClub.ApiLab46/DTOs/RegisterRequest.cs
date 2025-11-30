namespace BoardGameClub.ApiLab46.DTOs;

public record RegisterRequest(string Name, string Email, string Password, string Role = "Member");