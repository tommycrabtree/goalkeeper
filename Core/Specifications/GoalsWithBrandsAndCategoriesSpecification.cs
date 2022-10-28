using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class GoalsWithBrandsAndCategoriesSpecification : BaseSpecification<Goal>
{
    public GoalsWithBrandsAndCategoriesSpecification()
    {
        AddInclude(x => x.GoalBrand);
        AddInclude(x => x.GoalCategory);
    }

    public GoalsWithBrandsAndCategoriesSpecification(int id)
         : base(x => x.Id ==id)
    {
        AddInclude(x => x.GoalBrand);
        AddInclude(x => x.GoalCategory);
    }
}
