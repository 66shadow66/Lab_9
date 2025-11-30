using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.ApiLab46.Controllers;

[ApiController]
[Route("api/admin")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    [HttpGet("secret")]
    public IActionResult GetSecret()
    {
        return Ok("ТІЛЬКИ АДМІН БАЧИТЬ ЦЕ! Ти — бог клубу!");
    }

    [HttpGet("users")]
    public IActionResult GetAllUsers()
    {
        return Ok("Тут би був список всіх користувачів (якщо б ми його зробили)");
    }
}