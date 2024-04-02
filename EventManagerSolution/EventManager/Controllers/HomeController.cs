using EventManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventManager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
