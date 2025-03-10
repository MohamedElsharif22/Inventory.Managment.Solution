using Microsoft.AspNetCore.Identity;

namespace Inventory.Managment.Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string ProfilePictureUrl { get; set; } = null!;
    }
}
