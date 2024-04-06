using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Address { get; set; }

        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public EventType Type { get; set; } = null!;
    }
}
