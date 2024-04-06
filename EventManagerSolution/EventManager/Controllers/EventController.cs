using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
