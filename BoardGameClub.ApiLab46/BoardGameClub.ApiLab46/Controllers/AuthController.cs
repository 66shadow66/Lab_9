using BoardGameClub.ApiLab46.DTOs;
using BoardGameClub.ApiLab46.Models;
using BoardGameClub.ApiLab46.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.ApiLab46.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly TokenService _tokenService;

    public AuthController(IUserService userService, TokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest req)
    {
        if (await _userService.GetByEmailAsync(req.Email) != null)
            return BadRequest("Користувач вже існує");

        var user = new User
        {
            Name = req.Name,
            Email = req.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password),
            Role = req.Role == "Admin" ? "Admin" : "Member"
        };

        await _userService.CreateAsync(user);
        return Ok(new { message = "Зареєстровано", role = user.Role });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest req)
    {
        var user = await _userService.GetByEmailAsync(req.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
            return Unauthorized("Неправильно");

        var token = _tokenService.GenerateToken(user);
        return Ok(new { token, user.Name, user.Role });
    }
}