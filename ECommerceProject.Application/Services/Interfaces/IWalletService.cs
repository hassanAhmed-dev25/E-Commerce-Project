using ECommerceProject.Application.DTOs.Admin;
using ECommerceProject.Application.DTOs.Wallet;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IWalletService
    {
        // Wallet
        Task<GetWalletDto> GetOrCreateWalletAsync(string userId);
        Task<IEnumerable<WithdrawalRequestDto>> GetAllWithdrawalRequests(string userId);
        Task<IEnumerable<GetManageWithdrawalsDto>> GetAllWithdrawalRequestsForAllUsersAsync();
        Task SendMoneyToSellers(int orderId);

        Task<decimal> GetTotalSalesAsync(string sellerId);
        Task<decimal> GetWalletBalanceAsync(string sellerId);
        Task<decimal> GetWalletPendingWithdrawalsAsync(string sellerId);



        // Seller
        Task RequestWithdrawalAsync(string sellerId, decimal amount);
        Task CompleteWithdrawalAsync(string sellerId, int withdrawalRequestId);


        // Admin
        Task ApproveWithdrawalAsync(int withdrawalRequestId);
        Task RejectWithdrawalAsync(int withdrawalRequestId);

        Task<decimal> GetTotalRevenue();
        Task<int> GetTotalPendingWithdrawals();


    }
}
