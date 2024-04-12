using EventManager.Data;
using EventManager.Models;
using EventManager.Models.DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventManager.Controllers
{
    public class InterestedEventController : Controller
    {
        Repository<UserEventInterest> _userInterestLevelDb;

        public InterestedEventController(AppDbContext ctx)
        {
            _userInterestLevelDb = new Repository<UserEventInterest>(ctx);
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

            _userInterestLevelDb.Add(userInterest);
            _userInterestLevelDb.Save();

            return RedirectToAction("Details", "Event", new { id = eventId});
        }
    }
}
