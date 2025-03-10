using Inventory.Managment.Core.Entities;
using System.Linq.Expressions;

namespace Inventory.Managment.Core.Specificarion
{
    public interface ISpecification<T> where T : BaseEntity
    {
        Expression<Func<T, bool>>? Criteria { get; set; }
        List<Expression<Func<T, object>>> Includes { get; set; }

        public Expression<Func<T, object>> OrderByAsc { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPagenationEnabled { get; set; }
    }
}
