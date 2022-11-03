using API.DTOs;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class GoalsController : BaseAPIController
{
    private readonly IGenericRepository<Goal> _goalRepo;
    private readonly IGenericRepository<GoalBrand> _goalBrandRepo;
    private readonly IGenericRepository<GoalCategory> _goalCategoryRepo;
    private readonly IMapper _mapper;

    public GoalsController(IGenericRepository<Goal> goalRepo,
        IGenericRepository<GoalBrand> goalBrandRepo,
        IGenericRepository<GoalCategory> goalCategoryRepo,
        IMapper mapper)
    {
        _mapper = mapper;
        _goalCategoryRepo = goalCategoryRepo;
        _goalBrandRepo = goalBrandRepo;
        _goalRepo = goalRepo;
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<GoalToReturnDTO>>> GetGoals(
        [FromQuery]GoalSpecParams goalParams)
    {
        var spec = new GoalsWithBrandsAndCategoriesSpecification(goalParams);

        var countSpec = new GoalWithFiltersForCountSpecification(goalParams);

        var totalItems = await _goalRepo.CountAsync(countSpec);

        var goals = await _goalRepo.ListAsync(spec);

        var data = _mapper.Map<IReadOnlyList<Goal>,
            IReadOnlyList<GoalToReturnDTO>>(goals);

        return Ok(new Pagination<GoalToReturnDTO>(goalParams.PageIndex,
            goalParams.PageSize, totalItems, data));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(APIResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GoalToReturnDTO>> GetGoal(int id)
    {
        var spec = new GoalsWithBrandsAndCategoriesSpecification(id);

        var goal = await _goalRepo.GetEntityWithSpec(spec);

        if (goal == null) return NotFound(new APIResponse(404));

        return _mapper.Map<Goal, GoalToReturnDTO>(goal);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<GoalBrand>> GetGoalBrands()
    {
        return Ok(await _goalBrandRepo.ListAllAsync());
    }

    [HttpGet("categories")]
    public async Task<ActionResult<GoalCategory>> GetGoalCategories()
    {
        return Ok(await _goalCategoryRepo.ListAllAsync());
    }
}
