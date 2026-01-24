using ECommerceProject.Application.DTOs.Wallet;

namespace ECommerceProject.Application.Services.Implementation
{
    public class WalletService : IWalletService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WalletService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // Wallet
        public async Task<GetWalletDto> GetOrCreateWalletAsync(int userId)
        {
            try
            {
                var res = await _unitOfWork.walletRepository.GetAsync(w => w.UserId == userId);


                // return it if its already exists
                if (res != null)
                {
                    return new GetWalletDto
                    {
                        Balance = res.Balance,
                    };
                }

                var newWallet = new Wallet
                {
                    Balance = 0,
                    UserId = userId,
                };


                // Create it
                await _unitOfWork.walletRepository.AddAsync(newWallet);

                // Save it
                await _unitOfWork.SaveChangesAsync();


                // return it
                return new GetWalletDto
                {
                    Balance = newWallet.Balance,
                };


            }
            catch(Exception)
            {
                throw;
            }
        }



        // Seller
        public Task RequestWithdrawalAsync(int sellerId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task CompleteWithdrawalAsync(int withdrawalRequestId)
        {
            throw new NotImplementedException();
        }




        // Admin
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
