using Core.Entities;

namespace Core.Specifications;

public class GoalWithFiltersForCountSpecification : BaseSpecification<Goal>
{
    public GoalWithFiltersForCountSpecification(GoalSpecParams goalParams)
    : base(x =>
            (string.IsNullOrEmpty(goalParams.Search) || x.Name.ToLower()
                .Contains(goalParams.Search)) &&
            (!goalParams.GoalBrandId.HasValue || x.GoalBrandId == goalParams.GoalBrandId) &&
            (!goalParams.GoalCategoryId.HasValue || x.GoalCategoryId == goalParams.GoalCategoryId)
        )
    {
    }
}
