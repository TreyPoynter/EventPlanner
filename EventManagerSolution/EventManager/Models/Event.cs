using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string? Name { get; set; }

        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public EventType Type { get; set; } = null!;

        public ICollection<UserEventInterest> InterestedUsers { get; set; }

        public Event()
        {
            InterestedUsers = new HashSet<UserEventInterest>();
        }
    }
}
