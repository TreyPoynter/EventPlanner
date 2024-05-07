
using EventManager.Models.DataLayer;
using EventManager.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace EventManager.Areas.Identity.Pages.Account.Manage
{
    public class MyEventsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Repository<Event> _eventsDb;

        public MyEventsModel(UserManager<ApplicationUser> userManager, Repository<Event> eventsDb,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _eventsDb = eventsDb;
            _signInManager = signInManager;

        }

        public List<Event> UserEvents { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync()
        {
            bool isSignedIn = _signInManager.IsSignedIn(User);
            if (isSignedIn)
            {
                string? userId =  _userManager.GetUserId(User);
                UserEvents = _eventsDb.List(new QueryOptions<Event>()
                {
                    Includes = "Type, Coordinator",
                    Where = e => e.UserId == userId
                }).ToList();
                return Page();
            }

            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }
    }
}
