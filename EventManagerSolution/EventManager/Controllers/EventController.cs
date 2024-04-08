using EventManager.Data;
using EventManager.Models;
using EventManager.Models.DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        private readonly Repository<EventType> typesDb;
        private readonly Repository<UserEventInterest> interestsDb;
        private readonly Repository<Event> eventsDb;

        public EventController(AppDbContext ctx)
        {
            typesDb = new Repository<EventType>(ctx);
            interestsDb = new Repository<UserEventInterest>(ctx);
            eventsDb = new Repository<Event>(ctx);
        }

        [Route("/Events")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.EventTypes = typesDb.List(new QueryOptions<EventType>());

            return View();
        }

        [HttpPost]
        public IActionResult Create(Event @event)
        {
            @event.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(@event);
        }
    }
}
