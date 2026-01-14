using ECommerceProject.Application.DTOs.Account;
using ECommerceProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceProject.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServive _accountServive;
        public AccountController(IAccountServive accountServive, IEmailService emailService)
        {
            _accountServive = accountServive;
        }




        // Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser model)
        {

            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            var result = await _accountServive.RegisterUserAsync(model, baseUrl);

            if (result.Succeeded)
            {
                return RedirectToAction("ConfirmEmailNotice");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }

            return View(model);
        }


        //ConfirmEmailNotice
        [HttpGet]
        public IActionResult ConfirmEmailNotice()
        {
            return View();
        }




        // Confirm Email
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(VerifyEmailDto verifyEmail)
        {
            var result = await _accountServive.VerifyEmailAsync(verifyEmail);

            if (result.Succeeded)
                return View("ConfirmEmailSuccess");

            return View("ConfirmEmailFailed");
        }







        public IActionResult Index()
        {
            return View();
        }
    }
}
