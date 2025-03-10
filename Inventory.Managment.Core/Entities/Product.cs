namespace Inventory.Managment.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int QuantityInStock { get; set; }
        public string? Supplier { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }
}
