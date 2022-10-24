using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class GoalConfiguration : IEntityTypeConfiguration<Goal>
{
    public void Configure(EntityTypeBuilder<Goal> builder)
    {
        builder.Property(g => g.Id).IsRequired();
        builder.Property(g => g.Name).IsRequired();
        builder.Property(g => g.PictureUrl).IsRequired();
        builder.HasOne(b => b.GoalBrand).WithMany()
            .HasForeignKey(g => g.GoalBrandId);
        builder.HasOne(c => c.GoalCategory).WithMany()
            .HasForeignKey(g => g.GoalCategoryId);
    }
}
