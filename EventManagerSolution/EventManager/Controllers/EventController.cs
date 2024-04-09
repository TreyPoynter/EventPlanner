using EventManager.Data;
using EventManager.Models;
using EventManager.Models.DataLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection;
using System.Security.Claims;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        private readonly Repository<EventType> typesDb;
        private readonly Repository<UserEventInterest> interestsDb;
        private readonly Repository<Event> eventsDb;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventController(AppDbContext ctx, IWebHostEnvironment webHostEnvironment)
        {
            typesDb = new Repository<EventType>(ctx);
            interestsDb = new Repository<UserEventInterest>(ctx);
            eventsDb = new Repository<Event>(ctx);
            _webHostEnvironment = webHostEnvironment;

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
        public async Task<IActionResult> CreateAsync(EventViewModel @event)
        {
            @event.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid && @event.IconImage != null && @event.BannerImage != null)
            {
                string bannerPath = await UploadFileAsync(@event.BannerImage, "eventImages/headers");
                string iconPath = await UploadFileAsync(@event.BannerImage, "eventImages/icons");

                Event eventObj = new Event
                {
                    Name = @event.Name,
                    Description = @event.Description,
                    Address = @event.Address,
                    StartTime = @event.StartTime,
                    EndTime = @event.EndTime,
                    IsEveryoneInvited = @event.IsEveryoneInvited,
                    UserId = @event.UserId,
                    EventBanner = Path.GetFileName(@event.BannerImage.FileName),
                    EventIcon = Path.GetFileName(@event.IconImage.FileName),
                };
                eventsDb.Add(eventObj);
                return RedirectToAction("Index");
            }
            ViewBag.EventTypes = typesDb.List(new QueryOptions<EventType>());
            return View(@event);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string directory)
        {
            string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, directory);
            string fileName = Path.GetFileName(file.FileName);
            string filePath = Path.Combine(uploadDir, fileName);

            // Ensure directory exists
            Directory.CreateDirectory(uploadDir);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }
    }
}
