using Inventory.Managment.Core.Entities;
using Inventory.Managment.Core.Specificarion;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Managment.Application.Specification
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> BuildQuary(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)
                query = query.Where(specification.Criteria);

            if (specification.OrderByAsc != null)
                query = query.OrderBy(specification.OrderByAsc);
            else if (specification.OrderByDesc != null)
                query = query.OrderByDescending(specification.OrderByDesc);

            if (specification.IsPagenationEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            query = specification.Includes.Aggregate(query, (currentQuery, currentExpression) => currentQuery.Include(currentExpression));

            return query;
        }
    }
}
