using Inventory.Managment.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Managment.Application._Identity
{
    public class AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



        }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
