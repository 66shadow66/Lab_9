using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGameClub.ApiLab46.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet("private")]
    [Authorize]  
    public IActionResult GetPrivate()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        return Ok(new
        {
            Message = "Це приватний ендпойнт — ти успішно авторизувався!",
            UserId = userId,
            Email = email,
            Role = role
        });
    }

    [HttpGet("public")]
    public IActionResult GetPublic()
    {
        return Ok(new { Message = "Це публічний ендпойнт — доступний без токена" });
    }
}