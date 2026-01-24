using ECommerceProject.Application.DTOs.Wallet;
using System.Numerics;

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
        public async Task RequestWithdrawalAsync(int sellerId, decimal amount)
        {
            try
            {
                // Validation
                if (amount <= 0)
                    throw new ArgumentException("Amount must be greater than zero.");

                var wallet = await _unitOfWork.walletRepository.GetAsync(w => w.UserId == sellerId);

                if (wallet == null)
                    throw new Exception("Wallet not found.");

                if (wallet.Balance < amount)
                    throw new Exception("Insufficient balance.");


                // Create Withdrawal Request
                var request = new WithdrawalRequest
                {
                    Amount = amount,
                    WithdrawalStatus = WithdrawalStatus.Pending,
                    SellerId = sellerId,
                    RequestedAt = DateTime.UtcNow,
                };

                // Withdraw the money
                wallet.Balance -= amount;


                // Create the rquest
                await _unitOfWork.WithdrawalRepository.AddAsync(request);

                // Update the wallet
                await _unitOfWork.walletRepository.UpdateAsync(wallet);


                // Save it
                await _unitOfWork.SaveChangesAsync();

            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task CompleteWithdrawalAsync(int sellerId, int withdrawalRequestId)
        {
            try
            {
                // Validation
                var wallet = await _unitOfWork.walletRepository.GetAsync(w => w.UserId == sellerId);

                if (wallet == null)
                    throw new Exception("Wallet not found.");


                // Get Withdrawal Request
                var request = await _unitOfWork.WithdrawalRepository.GetAsync(wr => wr.Id == withdrawalRequestId && wr.SellerId == sellerId);

                if (request == null)
                    throw new Exception("Withdrawal rquest found.");

                if (request.WithdrawalStatus != WithdrawalStatus.Pending)
                    throw new Exception("Withdrawal request is not pending.");



                // Complete withdrawal
                request.WithdrawalStatus = WithdrawalStatus.Completed;
                request.CompletedAt = DateTime.UtcNow;



                // Update the Request
                await _unitOfWork.WithdrawalRepository.UpdateAsync(request);


                // Save it
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
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
