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


        // Manage Users
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

        public async Task<IActionResult> BlockUser(string userId)
        {
            return Ok();
        }



        // Manage Withdrawals
        public IActionResult ManageWithdrawals()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetAllWithdrawalsAjax()
        {
            var withdrawals = await _adminService.GetAllWithdrawalsAsync();

            return Json(new
            {
                draw = Request.Form["draw"],
                recordsTotal = withdrawals.Count(),
                recordsFiltered = withdrawals.Count(),
                data = withdrawals
            });
        }



        // Approve and Reject Withdrawal
        public async Task<IActionResult> UpdateWithdrawalStatusAjax(int withdrawalRequestId, string action)
        {
           
            if (action == "approve")
            {
                await _adminService.ApproveWithdrawalsAsync(withdrawalRequestId);
            }
            else if (action == "reject")
            {
                await _adminService.RejectWithdrawalsAsync(withdrawalRequestId);
            }
            else
            {
                return Json(new { success = false, message = "Invalid action" });
            }


            return Json(new
            {
                success = true,
                message = $"Withdrawal {action}d successfully"
            });

        }


    }
}
