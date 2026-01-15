using ECommerceProject.Application.DTOs.Account;
using ECommerceProject.Application.Services.Interfaces;
using ECommerceProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Tsp;
using System.Data;


namespace ECommerceProject.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServive _accountServive;
        public AccountController(IAccountServive accountServive)
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



        //Confirm Email Notice
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




        // Login
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInUser user)
        {

            var loginResponse = await _accountServive.LoginUserAsync(user);

            if (loginResponse.isSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Password", $"{loginResponse.errorMessege}");
                return View(user);
            }

        }






        // Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _accountServive.LogOutAsync();

            return RedirectToAction("Login", "Account");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
