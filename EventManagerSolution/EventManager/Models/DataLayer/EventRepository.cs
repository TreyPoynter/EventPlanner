using EventManager.Data;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Models.DataLayer
{
    public class EventRepository<T> : Repository<T> where T : class
    {
        private readonly DbSet<Event> _events;

        public EventRepository(AppDbContext ctx) : base(ctx)
        {
            _events = ctx.Set<Event>();
        }

        public Event? GetEventById(int id)
        {
            return _events.Include(e => e.User).Include(e => e.Type)
                .FirstOrDefault(e => e.EventId == id);
        }
    }
}
