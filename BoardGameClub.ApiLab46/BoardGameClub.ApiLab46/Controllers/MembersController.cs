using BoardGameClub.ApiLab46.Models;
using BoardGameClub.ApiLab46.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.ApiLab46.Controllers;

[ApiController]
[Route("api/members")]
[Authorize] // всі методи захищені токеном
public class MembersController : ControllerBase
{
    private readonly IMemberService _service;

    public MembersController(IMemberService service)
    {
        _service = service;
    }

    // GET: api/members
    [HttpGet]
    public async Task<ActionResult<List<Member>>> GetAll()
        => Ok(await _service.GetAllAsync());

    // GET: api/members/507f1f77bcf86cd799439011
    [HttpGet("{id}")]
    public async Task<ActionResult<Member>> GetById(string id)
    {
        var member = await _service.GetByIdAsync(id);
        return member == null ? NotFound() : Ok(member);
    }

    // POST: api/members
    [HttpPost]
    public async Task<ActionResult> Create(Member member)
    {
        await _service.CreateAsync(member);
        return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
    }

    // PUT: api/members/507f1f77bcf86cd799439011
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Member member)
    {
        if (id != member.Id) return BadRequest("ID в URL і тілі не співпадають");
        await _service.UpdateAsync(id, member);
        return NoContent();
    }

    // DELETE: api/members/507f1f77bcf86cd799439011
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}