using EventManager.Data;
using EventManager.Models.DataLayer;
using EventManager.Models.DomainModels;
using EventManager.Utilities;
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
        public IActionResult Create()
        {
            ViewBag.EventTypes = typesDb.List(new QueryOptions<EventType>());

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EventViewModel @event)
        {
            @event.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid && @event.IconImage != null && @event.BannerImage != null)
            {
                string bannerPath = await FileHelper.UploadFileAsync(@event.BannerImage, 
                    "eventImages\\headers", _webHostEnvironment);
                string iconPath = await FileHelper.UploadFileAsync(@event.IconImage, 
                    "eventImages\\icons", _webHostEnvironment);

                Event eventObj = new Event
                {
                    EventBanner = Path.GetFileName(@event.BannerImage.FileName),
                    EventIcon = Path.GetFileName(@event.IconImage.FileName),
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
            ViewBag.IsRSVP = interestsDb.UserIsInterested(id, userId);
            ViewBag.LoggedInUser = userId;
            ViewBag.HostEvents = eventsDb.GetEventsByUser(@event.UserId).Count();
            return View(@event);
        }
    }
}
