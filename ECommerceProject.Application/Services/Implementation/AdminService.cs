using ECommerceProject.Application.DTOs.Admin;

namespace ECommerceProject.Application.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IUserService _userService;
        private readonly IWalletService _walletService;
        public AdminService(IUserService userService, IWalletService walletService)
        {
            _userService = userService;
            _walletService = walletService;
        }

        public async Task<IEnumerable<GetUserDto>> GetAllUsersWithRolesAsync()
        {
            return await _userService.GetAllWithRolesAsync();
        }




        public async Task<IEnumerable<GetManageWithdrawalsDto>> GetAllWithdrawalsAsync()
        {
            return await _walletService.GetAllWithdrawalRequestsForAllUsersAsync();
        }



        public async Task ApproveWithdrawalsAsync(int withdrawalRequestId)
        {
            await _walletService.ApproveWithdrawalAsync(withdrawalRequestId);
        }
        public async Task RejectWithdrawalsAsync(int withdrawalRequestId)
        {
            await _walletService.RejectWithdrawalAsync(withdrawalRequestId);
        }

        
        
    }
}
