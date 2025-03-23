using Inventory.Managment.Core.Entities;
using Inventory.Managment.Core.Specification;
using Inventory.Managment.Core.Specification.product_specs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inventory.Managment.Application.Specification.product_specificarions
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(ProductSpecParams specParams, bool getCountOnly = false)
            : base(p => !specParams.CategoryId.HasValue || specParams.CategoryId == p.Id
                        && string.IsNullOrWhiteSpace(specParams.Search) || EF.Functions.Like(p.Name, $"%{specParams.Search}%"))
        {
            if (!getCountOnly)
            {
                AddInclude(P => P.Category);
                switch (specParams.Sort?.ToLower())
                {
                    case "name":
                        AddOrderByAsc(P => P.Name);
                        break;
                    case "priceasc":
                        AddOrderByAsc(P => P.Price);
                        break;
                    case "pricedesc":
                        AddOrderByDesc(P => P.Price);
                        break;
                    default:
                        AddOrderByAsc(P => P.Name);
                        break;
                }

                ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
            }
        }

        public ProductSpecification(Expression<Func<Product, bool>> criteriaExpression) : base(criteriaExpression)
        {
            AddInclude(P => P.Category);
        }




    }
}
