using Inventory.Managment.Core.Entities;
using System.Text.Json;

namespace Inventory.Managment.Application._Data
{
    public static class InventoryDbContextSeed
    {
        public static async Task SeedDataAsync(InventoryDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categoriesFile = await File.ReadAllTextAsync(@"../Inventory.Managment.Application/_Data/seed/categories.json");
                var categories = JsonSerializer.Deserialize<IEnumerable<Category>>(categoriesFile);

                if (categories?.Count() > 0)
                {
                    foreach (var category in categories)
                    {
                        await context.Set<Category>().AddAsync(category);

                    }
                    await context.SaveChangesAsync();
                }

            }
            //Check if any products exist
            if (!context.Products.Any())
            {
                var productsFile = await File.ReadAllTextAsync(@"../Inventory.Managment.Application/_Data/seed/products.json");
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(productsFile);

                if (products?.Count() > 0)
                {
                    foreach (var product in products)
                    {
                        await context.Products.AddAsync(product);

                    }
                    await context.SaveChangesAsync();
                }

            }

        }

    }
}
