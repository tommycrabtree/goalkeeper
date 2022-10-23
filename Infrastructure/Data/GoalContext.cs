using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GoalContext : DbContext
{
    public GoalContext(DbContextOptions<GoalContext> options) : base(options)
    {
    }

    public DbSet<Goal> Goals { get; set; }
    
}
