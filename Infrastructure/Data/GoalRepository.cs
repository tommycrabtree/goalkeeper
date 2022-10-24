using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GoalRepository : IGoalRepository
{
    private readonly GoalContext _context;
    public GoalRepository(GoalContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<GoalBrand>> GetGoalBrandsAsync()
    {
        return await _context.GoalBrands.ToListAsync();
    }

    public async Task<Goal> GetGoalByIdAsync(int id)
    {
        return await _context.Goals
            .Include(b => b.GoalBrand)
            .Include(c => c.GoalCategory)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IReadOnlyList<GoalCategory>> GetGoalCategoriesAsync()
    {
        return await _context.GoalCategories.ToListAsync();
    }

    public async Task<IReadOnlyList<Goal>> GetGoalsAsync()
    {
        return await _context.Goals
            .Include(b => b.GoalBrand)
            .Include(c => c.GoalCategory)
            .ToListAsync();
    }
}
