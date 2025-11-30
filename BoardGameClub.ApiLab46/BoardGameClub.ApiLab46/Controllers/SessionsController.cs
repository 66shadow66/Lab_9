using BoardGameClub.ApiLab46.Models;
using BoardGameClub.ApiLab46.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.ApiLab46.Controllers;

[ApiController]
[Route("api/sessions")]
[Authorize] // захищено токеном
public class SessionsController : ControllerBase
{
    private readonly ISessionService _service;

    public SessionsController(ISessionService service)
    {
        _service = service;
    }

    // GET: api/sessions
    [HttpGet]
    public async Task<ActionResult<List<Session>>> GetAll()
        => Ok(await _service.GetAllAsync());

    // GET: api/sessions/507f1f77bcf86cd799439011
    [HttpGet("{id}")]
    public async Task<ActionResult<Session>> GetById(string id)
    {
        var session = await _service.GetByIdAsync(id);
        return session == null ? NotFound() : Ok(session);
    }

    // POST: api/sessions
    [HttpPost]
    public async Task<ActionResult> Create(Session session)
    {
        await _service.CreateAsync(session);
        return CreatedAtAction(nameof(GetById), new { id = session.Id }, session);
    }

    // PUT: api/sessions/507f1f77bcf86cd799439011
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Session session)
    {
        if (id != session.Id) return BadRequest("ID в URL і тілі не співпадають");
        await _service.UpdateAsync(id, session);
        return NoContent();
    }

    // DELETE: api/sessions/507f1f77bcf86cd799439011
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}