using Inventory.Managment.Core.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Managment.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public string Type { get; set; } = null!;
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
        public string UserId { get; set; } = null!;
        [NotMapped]
        public ApplicationUser? User { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
