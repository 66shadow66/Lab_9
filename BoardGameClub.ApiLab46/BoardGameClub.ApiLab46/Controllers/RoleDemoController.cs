using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameClub.ApiLab46.Controllers;

[ApiController]
[Route("api/demo")]
public class RoleDemoController : ControllerBase
{
    [HttpGet("public")]
    public IActionResult Public() => Ok("Доступно всім");

    [HttpGet("member")]
    [Authorize]
    public IActionResult MemberOnly()
    {
        var role = User.FindFirst(ClaimTypes.Role)?.Value;
        return Ok($"Привіт! Ти — {role}");
    }

    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminOnly() => Ok("ТІЛЬКИ АДМІН БАЧИТЬ ЦЕ!");
}