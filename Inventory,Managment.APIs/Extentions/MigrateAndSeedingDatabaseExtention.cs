using Inventory.Managment.Application._Data;
using Inventory.Managment.Application._Identity;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Managment.APIs.Extentions
{
    public static class MigrateAndSeedingDatabaseExtention
    {
        public static async Task<WebApplication> MigrateAndSeedDatebasesAsync(this WebApplication webApplication)
        {
            using var scope = webApplication.Services.CreateScope();
            var services = scope.ServiceProvider;
            var inventoryDbContext = services.GetRequiredService<InventoryDbContext>();
            var identityDbContext = services.GetRequiredService<AppIdentityDbContext>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                //Migrate main app Context
                await inventoryDbContext.Database.MigrateAsync();
                await identityDbContext.Database.MigrateAsync();

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error occured while running Migration.");
            }
            // seed data to databases
            try
            {

                await InventoryDbContextSeed.SeedDataAsync(inventoryDbContext);

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error occured while seeding inventory data");
            }
            return webApplication;
        }

    }
}
