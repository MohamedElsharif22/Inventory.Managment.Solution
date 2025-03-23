using Inventory.Managment.APIs.DTOs;
using Inventory.Managment.Core.Entities;

namespace Inventory.Managment.APIs.Helpers.MappingProfiles
{
    public static class ProductMapping
    {
        public static ProductResponse MapToResponse(this Product product)
        {
            return new ProductResponse
            (
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.CategoryId,
                product.Category?.Name ?? string.Empty,
                product.QuantityInStock,
                product.Supplier,
                product.CreatedAt,
                product.UpdatedAt
            );
        }
    }
}
