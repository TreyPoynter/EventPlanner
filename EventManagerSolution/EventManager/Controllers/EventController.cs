using EventManager.Data;
using EventManager.Models.DataLayer;
using EventManager.Models.DomainModels;
using EventManager.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        private readonly Repository<EventType> typesDb;
        private readonly UserEventInterestRepo<UserEventInterest> interestsDb;
        private readonly EventRepository<Event> eventsDb;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventController(AppDbContext ctx, IWebHostEnvironment webHostEnvironment)
        {
            typesDb = new Repository<EventType>(ctx);
            interestsDb = new UserEventInterestRepo<UserEventInterest>(ctx);
            eventsDb = new EventRepository<Event>(ctx);
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("/Events")]
        public IActionResult Index()
        {
            List<Event> events = eventsDb.List(new QueryOptions<Event>()
            {
                Includes = "Coordinator, Type"
            }).ToList();

            return View(events);
        }
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.EventTypes = typesDb.List(new QueryOptions<EventType>());

            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(EventViewModel @event)
        {
            @event.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid && @event.BannerImage != null)
            {
                await FileHelper.UploadFileAsync(@event.BannerImage, 
                    "eventImages\\headers", _webHostEnvironment);

                Event eventObj = new Event
                {
                    EventBanner = Path.GetFileName(@event.BannerImage.FileName),
                };
                eventObj = @event;
                eventsDb.Add(eventObj);
                eventsDb.Save();
                return RedirectToAction("Index");
            }
            ViewBag.EventTypes = typesDb.List(new QueryOptions<EventType>());
            return View(@event);
        }

        public IActionResult Details(int id)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            Event? @event = eventsDb.GetEventById(id);
            UserEventInterest? interest = interestsDb.FindByIds(id, userId);
            ViewBag.IsRSVP = interest != null;

            if (ViewBag.IsRSVP)
                ViewBag.InterestStatus = interest.InterestLevel;

            ViewBag.LoggedInUser = userId;
            ViewBag.HostEvents = eventsDb.GetEventsByUser(@event.UserId).Count();
            return View(@event);
        }
    }
}
