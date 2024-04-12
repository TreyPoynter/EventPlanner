using Microsoft.AspNetCore.Identity;

namespace EventManager.Models.DomainModels
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<Event> Events { get; set; }

        public ApplicationUser()
        {
            Events = new List<Event>();
        }
    }
}
