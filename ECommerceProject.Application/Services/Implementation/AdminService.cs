using ECommerceProject.Application.DTOs.Admin;
using ECommerceProject.Application.DTOs.Wallet;

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

        public async Task<IEnumerable<WithdrawalRequestDto>> GetAllWithdrawalsAsync()
        {
            return await _walletService.GetAllWithdrawalRequestsForAllUsersAsync();
        }
    }
}
