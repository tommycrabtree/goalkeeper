namespace Core.Entities;

public class Goal : BaseEntity
{
    public string Name { get; set; }
    public string PictureUrl { get; set; }
    public int GoalCategoryId { get; set; }
    public GoalCategory GoalCategory { get; set; }
    public int GoalBrandId { get; set; }
    public GoalBrand GoalBrand { get; set; }
}
