using Microsoft.AspNetCore.Identity;

namespace EventManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<UserEventInterest> EventInterests { get; set; }

        public ApplicationUser()
        {
            EventInterests = new HashSet<UserEventInterest>();
        }
    }
}
