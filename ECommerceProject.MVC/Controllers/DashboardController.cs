using ECommerceProject.Application.Services.Interfaces;
using ECommerceProject.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceProject.MVC.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IWalletService _walletServive { get; set; }

        public DashboardController(IWalletService walletServive)
        {
            _walletServive = walletServive;
        }



        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return RedirectToAction("Admin");

            if (User.IsInRole("Seller"))
                return RedirectToAction("Seller");

            return Forbid();
        }


        //public async Task<IActionResult> Seller()
        //{
             
        //    var vm = new GetSellerDataForDashboardVM
        //    {
        //        WalletBalance = await _walletServive.get
        //    };

        //    return View(vm);
        //}

    }
}
