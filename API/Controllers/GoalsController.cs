using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GoalsController : ControllerBase
{
    private readonly IGoalRepository _repo;
    public GoalsController(IGoalRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Goal>>> GetGoals()
    {
        var goals = await _repo.GetGoalsAsync();

        return Ok(goals);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Goal>> GetGoal(int id)
    {
        return await _repo.GetGoalByIdAsync(id);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<GoalBrand>> GetGoalBrands()
    {
        return Ok(await _repo.GetGoalBrandsAsync());
    }

    [HttpGet("categories")]
    public async Task<ActionResult<GoalCategory>> GetGoalCategories()
    {
        return Ok(await _repo.GetGoalCategoriesAsync());
    }
}
