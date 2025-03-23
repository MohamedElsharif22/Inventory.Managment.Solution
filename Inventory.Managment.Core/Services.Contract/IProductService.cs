using Inventory.Managment.Core.Entities;
using Inventory.Managment.Core.Specification.product_specs;

namespace Inventory.Managment.Core.Services.Contract
{
    public interface IProductService
    {
        Task<(IReadOnlyList<Product>, int)> GetAllProductsWithSpecsAsync(ProductSpecParams specParams);
        Task<Product?> GetProductByIdAsync(int id);


    }
}
