using Inventory.Managment.APIs.DTOs;
using Inventory.Managment.APIs.Errors;
using Inventory.Managment.APIs.Helpers;
using Inventory.Managment.APIs.Helpers.MappingProfiles;
using Inventory.Managment.Core.Services.Contract;
using Inventory.Managment.Core.Specification.product_specs;

namespace Inventory.Managment.APIs.Endpoints
{
    public static class Endpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            #region Product Endpoints
            var productsGroup = app.MapGroup("api/products").WithName("Products");
            productsGroup.MapGet("", async ([AsParameters] ProductSpecParams specParams, IProductService productService) =>
            {

                var (products, count) = await productService.GetAllProductsWithSpecsAsync(specParams);

                return Results.Ok(new Pagination<ProductResponse>(specParams.PageIndex, specParams.PageSize, count, products.Select(P => P.MapToResponse())));

            }).WithSummary("Get All Products.");

            productsGroup.MapGet("{id}", async (int id, IProductService productService) =>
            {
                var product = await productService.GetProductByIdAsync(id);

                if (product is null)
                    return Results.NotFound(new ApiResponse(StatusCodes.Status404NotFound));

                return Results.Ok(product.MapToResponse());

            }).WithName("Get Product By Id")
            .WithSummary("Get Product By Id");

            #endregion
        }
    }
}
