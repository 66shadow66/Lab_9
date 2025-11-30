namespace BoardGameClub.ApiLab46.DTOs;

public record LoginRequest(string Email, string Password);
public record RegisterRequest(string Name, string Email, string Password);