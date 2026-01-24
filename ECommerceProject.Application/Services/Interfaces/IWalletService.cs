using ECommerceProject.Application.DTOs.Wallet;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IWalletService
    {
        // Wallet
        Task<GetWalletDto> GetOrCreateWalletAsync(string userId);


        // Seller
        Task RequestWithdrawalAsync(string sellerId, decimal amount);
        Task CompleteWithdrawalAsync(string sellerId, int withdrawalRequestId);


        // Admin
        Task ApproveWithdrawalAsync(int withdrawalRequestId);
        Task RejectWithdrawalAsync(int withdrawalRequestId);
    }
}
