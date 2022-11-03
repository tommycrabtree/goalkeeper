using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class GoalsWithBrandsAndCategoriesSpecification : BaseSpecification<Goal>
{
    public GoalsWithBrandsAndCategoriesSpecification(GoalSpecParams goalParams)
        : base(x =>
            (string.IsNullOrEmpty(goalParams.Search) || x.Name.ToLower()
                .Contains(goalParams.Search)) &&
            (!goalParams.GoalBrandId.HasValue || x.GoalBrandId == goalParams.GoalBrandId) &&
            (!goalParams.GoalCategoryId.HasValue || x.GoalCategoryId == goalParams.GoalCategoryId)
        )
    {
        AddInclude(x => x.GoalBrand);
        AddInclude(x => x.GoalCategory);
        AddOrderBy(x => x.Name);
        ApplyPaging(goalParams.PageSize * (goalParams.PageIndex - 1),
            goalParams.PageSize);

        if (!string.IsNullOrEmpty(goalParams.Sort))
        {
            switch (goalParams.Sort)
            {
                default:
                    AddOrderBy(n => n.Name);
                    break;
            }
        }
    }

    public GoalsWithBrandsAndCategoriesSpecification(int id)
         : base(x => x.Id ==id)
    {
        AddInclude(x => x.GoalBrand);
        AddInclude(x => x.GoalCategory);
    }
}
