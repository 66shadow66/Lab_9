using BoardGameClub.ApiLab46.Models;
using BoardGameClub.ApiLab46.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.ApiLab46.Controllers;

[ApiController]
[Route("api/games")]
[Authorize]
public class GamesController : ControllerBase
{
    private readonly IGameService _service;
    public GamesController(IGameService service) => _service = service;

    [HttpGet] public async Task<ActionResult<List<Game>>> GetAll() => Ok(await _service.GetAllAsync());
    [HttpGet("{id}")]

    public async Task<ActionResult<Game>> Get(string id)
    {
        var game = await _service.GetByIdAsync(id);
        return game == null ? NotFound() : Ok(game);
    }
    [HttpPost]


    public async Task<ActionResult> Create(Game game)
    {
        await _service.CreateAsync(game);
        return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
    }
    [HttpPut("{id}")]


    public async Task<IActionResult> Update(string id, Game game)
    {
        if (id != game.Id) return BadRequest();
        await _service.UpdateAsync(id, game);
        return NoContent();
    }
    [HttpDelete("{id}")]


    public async Task<IActionResult> Delete(string id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}