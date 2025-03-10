using Inventory.Managment.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Managment.Application._Data.Config
{
    internal class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(P => P.Description).IsRequired().HasColumnType("nvarchar(Max)");
            builder.Property(P => P.Price).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(P => P.Supplier).HasMaxLength(100);
            builder.Property(P => P.CreatedAt).HasColumnType("datetimeoffset");
            builder.Property(P => P.UpdatedAt).HasColumnType("datetimeoffset");
            builder.HasOne(P => P.Category).WithMany();
        }
    }
}
