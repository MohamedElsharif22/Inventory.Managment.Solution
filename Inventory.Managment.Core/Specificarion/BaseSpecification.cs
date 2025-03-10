using Inventory.Managment.Core.Entities;
using System.Linq.Expressions;

namespace Inventory.Managment.Core.Specificarion
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }
        public Expression<Func<T, object>> OrderByAsc { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPagenationEnabled { get; set; }
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>>? criteriaExpression)
        {
            Criteria = criteriaExpression;
        }
        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }
        protected virtual void AddOrderByAsc(Expression<Func<T, object>> orderByAscExpression)
        {
            OrderByAsc = orderByAscExpression;
        }
        protected virtual void ApplyPagination(int skip, int take)
        {
            IsPagenationEnabled = true;
            Skip = skip;
            Take = take;
        }
    }
}
