using EventManager.Data;
using EventManager.Models;
using EventManager.Models.DataLayer;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult AddInterest(InterestLevel interestLevel)
        {
            return View();
        }
    }
}
