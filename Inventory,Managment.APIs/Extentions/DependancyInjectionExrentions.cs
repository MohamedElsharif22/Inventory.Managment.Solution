using Inventory.Managment.Application._Data;
using Inventory.Managment.Application._Identity;
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


            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }


        public static IServiceCollection AddAuthenticartionServices(this IServiceCollection services)
        {
            return services;
        }

    }
}
