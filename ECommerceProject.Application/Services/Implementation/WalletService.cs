using ECommerceProject.Application.DTOs.Wallet;

namespace ECommerceProject.Application.Services.Implementation
{
    public class WalletService : IWalletService
    {

        public Task<GetWalletDto> GetOrCreateWalletAsync(int userId)
        {
            throw new NotImplementedException();
        }




        public Task RequestWithdrawalAsync(int sellerId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task CompleteWithdrawalAsync(int withdrawalRequestId)
        {
            throw new NotImplementedException();
        }





        public Task ApproveWithdrawalAsync(int withdrawalRequestId)
        {
            throw new NotImplementedException();
        }
        

        public Task RejectWithdrawalAsync(int withdrawalRequestId)
        {
            throw new NotImplementedException();
        }

        
    }
}
