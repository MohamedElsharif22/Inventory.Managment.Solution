using Inventory.Managment.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Managment.Application._Data.Config
{
    public class LowStockConfigration : IEntityTypeConfiguration<LowStockAlert>
    {
        public void Configure(EntityTypeBuilder<LowStockAlert> builder)
        {
            builder.HasOne(L => L.Product).WithMany();
            builder.Property(P => P.Threshold).IsRequired();

        }
    }
}
