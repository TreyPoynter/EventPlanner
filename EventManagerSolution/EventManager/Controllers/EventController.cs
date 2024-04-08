using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        [Route("/Events")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
