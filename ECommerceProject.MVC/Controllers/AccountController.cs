using ECommerceProject.Application.DTOs.Account;
using ECommerceProject.Application.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            // Apply Fluent Validation
            //var validationResult = await validator.ValidateAsync(model);

            //if (!validationResult.IsValid)
            //{
            //    foreach (var error in validationResult.Errors)
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

            //    return View(model);
            //}



            var result = await _accountServive.RegisterUserAsync(model);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
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







        public IActionResult Index()
        {
            return View();
        }
    }
}
