namespace Inventory.Managment.Core.Entities.Payment
{
    public class Payment : BaseEntity
    {
        public int TransacrionId { get; set; }
        public Transaction Transaction { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }


    }
}
