using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public class GoalContextSeed
{
    public static async Task SeedAsync(GoalContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.GoalBrands.Any())
            {
                var brandsData =
                    File.ReadAllText("../Infrastructure/Data/SeedData/goalbrands.json");
                
                var brands = JsonSerializer.Deserialize<List<GoalBrand>>(brandsData);

                foreach (var item in brands)
                {
                    context.GoalBrands.Add(item);
                }

                await context.SaveChangesAsync();
            }

            if (!context.GoalCategories.Any())
            {
                var categoriesData =
                    File.ReadAllText("../Infrastructure/Data/SeedData/goalcategories.json");
                
                var categories = JsonSerializer.Deserialize<List<GoalCategory>>(categoriesData);

                foreach (var item in categories)
                {
                    context.GoalCategories.Add(item);
                }

                await context.SaveChangesAsync();
            }

            if (!context.Goals.Any())
            {
                var goalsData =
                    File.ReadAllText("../Infrastructure/Data/SeedData/goals.json");
                
                var goals = JsonSerializer.Deserialize<List<Goal>>(goalsData);

                foreach (var item in goals)
                {
                    context.Goals.Add(item);
                }

                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<GoalContextSeed>();
            logger.LogError(ex.Message);
        }
    }
}
