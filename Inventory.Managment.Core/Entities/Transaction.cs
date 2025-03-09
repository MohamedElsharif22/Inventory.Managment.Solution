using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Managment.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
        public string UserId { get; set; }
        [NotMapped]
        public ApplicationUser? User { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
