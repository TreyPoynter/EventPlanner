namespace EventManager.Models.DomainModels
{
    public class EventType
    {
        public int EventTypeId { get; set; }
        public string? Name { get; set; }

        public ICollection<Event> Events { get; set; }

        public EventType()
        {
            Events = new List<Event>();
        }
    }
}
