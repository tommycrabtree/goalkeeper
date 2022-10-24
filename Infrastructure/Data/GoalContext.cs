using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GoalContext : DbContext
{
    public GoalContext(DbContextOptions<GoalContext> options) : base(options)
    {
    }

    public DbSet<Goal> Goals { get; set; }
    public DbSet<GoalBrand> GoalBrands { get; set; }
    public DbSet<GoalCategory> GoalCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
