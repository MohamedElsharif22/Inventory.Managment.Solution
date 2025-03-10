using Inventory.Managment.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Inventory.Managment.Application._Data
{
    public class InventoryDbContext(DbContextOptions<InventoryDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<LowStockAlert> LowStockAlerts { get; set; }
    }

}
