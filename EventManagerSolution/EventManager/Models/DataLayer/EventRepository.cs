using EventManager.Data;
using EventManager.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Models.DataLayer
{
    public class EventRepository<T> : Repository<T> where T : Event
    {
        private readonly DbSet<Event> _events;

        public EventRepository(AppDbContext ctx) : base(ctx)
        {
            _events = ctx.Set<Event>();
        }

        public IEnumerable<Event> GetEventsByUser(string userId)
        {
            return _events.Where(e => e.UserId == userId);
        }

        public Event? GetEventById(int id)
        {
            return _events.Include(e => e.Coordinator).Include(e => e.Type)
                .FirstOrDefault(e => e.EventId == id);
        }
    }
}
