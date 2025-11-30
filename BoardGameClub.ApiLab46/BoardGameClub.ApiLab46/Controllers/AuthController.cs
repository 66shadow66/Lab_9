using BoardGameClub.ApiLab46.DTOs;
using BoardGameClub.ApiLab46.Models;
using BoardGameClub.ApiLab46.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.ApiLab46.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMemberService _memberService;
    private readonly ITokenService _tokenService;

    public AuthController(IMemberService memberService, ITokenService tokenService)
    {
        _memberService = memberService;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest req)
    {
        var member = new Member { Name = req.Name, Email = req.Email, PasswordHash = req.Password };
        await _memberService.CreateAsync(member);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest req)
    {
        var member = await _memberService.GetByEmailAsync(req.Email);
        if (member == null || !BCrypt.Net.BCrypt.Verify(req.Password, member.PasswordHash))
            return Unauthorized();

        var token = _tokenService.GenerateToken(member);
        return Ok(new { token });
    }
}