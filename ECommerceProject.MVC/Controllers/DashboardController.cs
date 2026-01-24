using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.MVC.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Admin");

            if (User.IsInRole("Seller"))
                return RedirectToAction("Seller");

            return Forbid();
        }


        public IActionResult Seller()
        {
            return View();
        }

    }
}
