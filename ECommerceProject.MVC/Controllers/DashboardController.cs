using ECommerceProject.Application.Services.Interfaces;
using ECommerceProject.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerceProject.MVC.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IWalletService _walletServive { get; set; }
        public IOrderService _orderService { get; set; }

        public DashboardController(IWalletService walletServive, IOrderService orderService)
        {
            _walletServive = walletServive;
            _orderService = orderService;
        }



        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Admin");

            if (User.IsInRole("Seller"))
                return RedirectToAction("Seller");

            return Forbid();
        }


        public async Task<IActionResult> Seller()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();


            var vm = new GetSellerDataForDashboardVM
            {
                TotalSales = await _walletServive.GetTotalSalesAsync(userId),
                WalletBalance = await _walletServive.GetWalletBalanceAsync(userId),
                PendingWithdrawals = await _walletServive.GetWalletPendingWithdrawalsAsync(userId),

                TotalOrders = await _orderService.GetTotalOrdersAsync(userId),
            };

            return View(vm);
        }



        public async Task<IActionResult> Admin()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var vm = new GetAdminDataForDashboardVM
            {
                
            };

            return View(vm);
        }

    }
}
