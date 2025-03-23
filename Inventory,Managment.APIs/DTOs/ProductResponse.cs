namespace Inventory.Managment.APIs.DTOs
{
    public record ProductResponse(int productId, string Name, string description,
                                  decimal price, int categoryId, string? categoryName,
                                  int quantityInStock, string? supplier, DateTimeOffset createdAt, DateTimeOffset updatedAt);

}
