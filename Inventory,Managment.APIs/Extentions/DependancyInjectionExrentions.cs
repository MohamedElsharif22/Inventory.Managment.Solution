using Inventory.Managment.Application;
using Inventory.Managment.Application._Data;
using Inventory.Managment.Application._Identity;
using Inventory.Managment.Core;
using Inventory.Managment.Core.Services.Contract;
using Inventory.Managment.Infrastructure;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

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
            services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }


        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
        {
            return services;
        }

    }
}
