using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.MVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
