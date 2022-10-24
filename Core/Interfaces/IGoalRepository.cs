using Core.Entities;

namespace Core.Interfaces;

public interface IGoalRepository
{
    Task<Goal> GetGoalByIdAsync(int id);
    Task<IReadOnlyList<Goal>> GetGoalsAsync();
    Task<IReadOnlyList<GoalBrand>> GetGoalBrandsAsync();
    Task<IReadOnlyList<GoalCategory>> GetGoalCategoriesAsync();
}
