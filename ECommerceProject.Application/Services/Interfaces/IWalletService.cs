using ECommerceProject.Application.DTOs.Wallet;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IWalletService
    {
        // Wallet
        Task<GetWalletDto> GetOrCreateWalletAsync(int userId);


        // Seller
        Task RequestWithdrawalAsync(int sellerId, decimal amount);
        Task CompleteWithdrawalAsync(int sellerId, int withdrawalRequestId);


        // Admin
        Task ApproveWithdrawalAsync(int withdrawalRequestId);
        Task RejectWithdrawalAsync(int withdrawalRequestId);
    }
}
