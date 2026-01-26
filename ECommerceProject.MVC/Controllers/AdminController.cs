using ECommerceProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManageUsers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _adminService.GetAllUsersWithRolesAsync();


            return Json(new
            {
                draw = Request.Form["draw"],
                recordsTotal = users.Count(),
                recordsFiltered = users.Count(),
                data = users
            });

        }

    }
}
