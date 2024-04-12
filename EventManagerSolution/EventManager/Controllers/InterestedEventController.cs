using EventManager.Data;
using EventManager.Models.DataLayer;
using EventManager.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventManager.Controllers
{
    public class InterestedEventController : Controller
    {
        UserEventInterestRepo<UserEventInterest> _interestDb;

        public InterestedEventController(AppDbContext ctx)
        {
            _interestDb = new UserEventInterestRepo<UserEventInterest>(ctx);
        }

        [HttpPost]
        public IActionResult AddInterest(InterestLevel interestLevel, int eventId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            UserEventInterest userInterest = new()
            {
                UserId = userId,
                EventId = eventId,
                InterestLevel = interestLevel,
            };

            _interestDb.Add(userInterest);
            _interestDb.Save();

            return RedirectToAction("Details", "Event", new { id = eventId});
        }

        [HttpPost]
        public IActionResult NotInterested(int eventId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserEventInterest? foundInterest = _interestDb.FindByIds(eventId, userId);

            if(foundInterest != null)
            {
                _interestDb.Delete(foundInterest);
                _interestDb.Save();
            }
            return RedirectToAction("Details", "Event", new { id = eventId });
        }
    }
}
