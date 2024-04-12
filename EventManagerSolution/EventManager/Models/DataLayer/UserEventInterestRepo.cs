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

        public bool UserIsInterested(int eventId, string? userId)
        {
            return _interests.All(x => x.UserId == userId && x.EventId == eventId);
        }

    }
}
