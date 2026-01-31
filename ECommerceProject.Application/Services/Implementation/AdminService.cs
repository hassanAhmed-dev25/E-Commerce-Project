using ECommerceProject.Application.DTOs.Admin;

namespace ECommerceProject.Application.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IWalletService _walletService;
        public AdminService(IUnitOfWork unitOfWork, IUserService userService, IWalletService walletService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _walletService = walletService;
        }

        public async Task<IEnumerable<GetUserDto>> GetAllUsersWithRolesAsync()
        {
            return await _userService.GetAllWithRolesAsync();
        }
        public async Task ToggleBlockAsync(string userId)
        {
            // Toggle
            await _userService.ToggleBlockAsync(userId);

            // Save
            await _unitOfWork.SaveChangesAsync();
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
