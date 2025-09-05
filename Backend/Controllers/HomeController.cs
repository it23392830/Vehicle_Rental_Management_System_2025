using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VehicleRentalSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                var user = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Admin")) return Redirect("~/Admin/Dashboard");
                if (roles.Contains("Manager")) return Redirect("~/Manager/Dashboard");
                if (roles.Contains("Driver")) return Redirect("~/Driver/Dashboard");
                return Redirect("~/Customer/Dashboard");
            }

            // Not logged in: show a simple landing with Login/Register links
            return View();
        }
    }
}
