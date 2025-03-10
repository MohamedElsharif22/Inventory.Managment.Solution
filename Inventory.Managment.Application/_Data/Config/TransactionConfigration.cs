using Inventory.Managment.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Managment.Application._Data.Config
{
    public class TransactionConfigration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(T => T.Product).WithMany();
            builder.Property(T => T.Quantity).IsRequired();
            builder.Property(T => T.UserId).IsRequired();
            builder.Property(T => T.TotalAmount).IsRequired().HasColumnType("decimal(10,2)");
        }
    }
}
