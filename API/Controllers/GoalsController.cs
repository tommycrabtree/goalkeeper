using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GoalsController : ControllerBase
{
    private readonly GoalContext _context;
    public GoalsController(GoalContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Goal>>> GetGoals()
    {
        var goals = await _context.Goals.ToListAsync();
        
        return Ok(goals);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Goal>> GetGoal(int id)
    {
        return await _context.Goals.FindAsync(id);
    }
}
