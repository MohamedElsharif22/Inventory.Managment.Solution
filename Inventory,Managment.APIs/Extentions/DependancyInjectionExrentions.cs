using Inventory.Managment.Application._Data;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Managment.APIs.Extentions
{
    public static class DependancyInjectionExrentions
    {
        public static IServiceCollection AddDatabasesServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InventoryDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MainConnection"));
            });
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

    }
}
