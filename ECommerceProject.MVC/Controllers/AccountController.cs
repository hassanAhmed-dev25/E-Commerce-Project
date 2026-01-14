using ECommerceProject.Application.DTOs.Account;
using ECommerceProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }




        // Register
        [HttpGet]
        public async Task<IActionResult> Register(string userId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser model)
        {
            var user = new IdentityUser()
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Password", item.Description);
                }
            }

            return View(model);
        }







        public IActionResult Index()
        {
            return View();
        }
    }
}
