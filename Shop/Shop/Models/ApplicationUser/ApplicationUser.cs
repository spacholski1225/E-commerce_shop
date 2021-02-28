using Microsoft.AspNetCore.Identity;

namespace Shop.Models.ApplicationUser
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
