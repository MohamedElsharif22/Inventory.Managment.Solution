using Inventory.Managment.Application.Specification.product_specificarions;
using Inventory.Managment.Core;
using Inventory.Managment.Core.Entities;
using Inventory.Managment.Core.Services.Contract;
using Inventory.Managment.Core.Specification.product_specs;

namespace Inventory.Managment.Infrastructure
{
    public sealed class ProductService(IUnitOfWork unitOfWork) : IProductService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<(IReadOnlyList<Product>, int)> GetAllProductsWithSpecsAsync(ProductSpecParams specParams)
        {
            var productRepo = _unitOfWork.Repository<Product>();
            var productsSpecs = new ProductSpecification(specParams);
            var products = await productRepo!.GetAllWithSpecsAsync(productsSpecs);
            var countSpecs = new ProductSpecification(specParams, true);
            var count = await productRepo!.GetCountAsync(countSpecs);
            return (products, count);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var spec = new ProductSpecification(P => P.Id == id);
            return await _unitOfWork.Repository<Product>()!.GetWithSpecsAsync(spec);
        }
    }
}
