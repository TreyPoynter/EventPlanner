using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Models
{
    public class UserEventInterest
    {
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public int EventId { get; set; }
        public Event Event { get; set; } = null!;

        public InterestLevel InterestLevel { get; set; } // Enum or custom class for interest levels
    }
}
