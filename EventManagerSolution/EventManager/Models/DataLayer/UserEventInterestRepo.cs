using EventManager.Data;
using EventManager.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Models.DataLayer
{
    public class UserEventInterestRepo<T> : Repository<T> where T : class
    {
        private readonly DbSet<UserEventInterest> _interests;
        public UserEventInterestRepo(AppDbContext ctx) : base(ctx)
        {
            _interests = ctx.Set<UserEventInterest>();
        }

        public UserEventInterest? FindByIds(int eventId, string? userId)
        {
            return _interests.FirstOrDefault(i => i.UserId == userId && i.EventId == eventId);
        }

        public bool UserIsInterested(int eventId, string? userId)
        {
            UserEventInterest? interest = _interests.FirstOrDefault(x => x.UserId == userId && x.EventId == eventId);

            return interest != null;
        }

    }
}
