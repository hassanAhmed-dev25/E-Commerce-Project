using ECommerceProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace ECommerceProject.MVC.Controllers
{
    [Authorize]
    public class WalletController : Controller
    {
        private IWalletService _walletService;
        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }


        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var res = await _walletService.GetOrCreateWalletAsync(userId);

            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> Withdraw()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var res = await _walletService.GetOrCreateWalletAsync(userId);

            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Withdraw(decimal amount)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            await _walletService.RequestWithdrawalAsync(userId, amount);

            return RedirectToAction("History");
        }



        [HttpGet]
        public IActionResult GetWithdrawals()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetWithdrawalsAjax()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var res = await _walletService.GetAllWithdrawalRequests(userId);

            return Json(new
            {
                
                recordsTotal = res.Count(),
                recordsFiltered = res.Count(),
                data = res
            });

        }
    } 
}
