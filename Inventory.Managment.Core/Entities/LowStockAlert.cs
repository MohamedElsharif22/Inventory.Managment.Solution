namespace Inventory.Managment.Core.Entities
{
    public class LowStockAlert : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Threshold { get; set; }
        public bool AlertSent { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
    }
}
