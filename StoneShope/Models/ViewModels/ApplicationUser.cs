using Microsoft.AspNetCore.Identity;

namespace StoneShope.Models.ViewModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
