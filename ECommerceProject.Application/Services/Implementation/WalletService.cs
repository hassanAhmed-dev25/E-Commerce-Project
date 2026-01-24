using ECommerceProject.Application.DTOs.Wallet;
using Microsoft.EntityFrameworkCore;


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
        public async Task<GetWalletDto> GetOrCreateWalletAsync(string userId)
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
        public async Task<IEnumerable<WithdrawalRequestDto>> GetAllWithdrawalRequests(string userId)
        {
            try
            {
                var requests = await _unitOfWork.WithdrawalRepository.GetAllAsync(w => w.SellerId == userId);


                // return it if its already exists
                if (requests == null)
                    throw new Exception("requests not found");


                return requests.Select(wi => new WithdrawalRequestDto
                {
                    Id = wi.Id,
                    Amount = wi.Amount,
                    RequestedAt = wi.RequestedAt,
                    WithdrawalStatus = wi.WithdrawalStatus
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SendMoneyToSellers(int orderId)
        {

            var order = await _unitOfWork.Orders.GetAsync(o => o.Id == orderId, 
                                                       q => q.Include(o => o.OrderItems));

            if (order == null)
                throw new Exception("Order not found");

            var sellers = order.OrderItems.GroupBy(oi => oi.SellerId).ToList();

            foreach(var seller in sellers)
            {
                var sellerId = seller.Key;
                var totalAmount = seller.Sum(oi => oi.Quantity * oi.UnitPrice);


                var wallet = await _unitOfWork.walletRepository.GetAsync(w => w.UserId == sellerId);

                if (wallet == null)
                {
                    wallet = new Wallet
                    {
                        UserId = sellerId,
                        Balance = totalAmount
                    };

                    await _unitOfWork.walletRepository.AddAsync(wallet);
                }
                else
                {
                    wallet.Balance += totalAmount;
                    await _unitOfWork.walletRepository.UpdateAsync(wallet);
                }

            }

            await _unitOfWork.SaveChangesAsync();
        }


        // Seller
        public async Task RequestWithdrawalAsync(string sellerId, decimal amount)
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

        public async Task CompleteWithdrawalAsync(string sellerId, int withdrawalRequestId)
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

                if (request.WithdrawalStatus != WithdrawalStatus.Approved)
                    throw new Exception("Withdrawal request is not approved.");



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
        public async Task ApproveWithdrawalAsync(int withdrawalRequestId)
        {
            try
            {
                // Validation


                // Get Withdrawal Request
                var request = await _unitOfWork.WithdrawalRepository.GetAsync(wr => wr.Id == withdrawalRequestId);

                if(request == null)
                    throw new Exception("Withdrawal request not found.");

                if (request.WithdrawalStatus != WithdrawalStatus.Pending)
                    throw new Exception("Withdrawal request is not pending.");



                // Complete withdrawal
                request.WithdrawalStatus = WithdrawalStatus.Approved;
                request.ApprovedAt = DateTime.UtcNow;



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
        

        public async Task RejectWithdrawalAsync(int withdrawalRequestId)
        {
            try
            {
                // Validation


                // Get Withdrawal Request
                var request = await _unitOfWork.WithdrawalRepository.GetAsync(wr => wr.Id == withdrawalRequestId);

                if (request == null)
                    throw new Exception("Withdrawal request not found.");

                if (request.WithdrawalStatus != WithdrawalStatus.Pending)
                    throw new Exception("Withdrawal request is not pending.");

                var wallet = await _unitOfWork.walletRepository.GetAsync(w => w.UserId == request.SellerId);

                if (wallet == null)
                    throw new Exception("Wallet not found.");



                // Reject withdrawal
                request.WithdrawalStatus = WithdrawalStatus.Rejected;
                request.ApprovedAt = DateTime.UtcNow;

                // Return money
                wallet.Balance += request.Amount;


                // Update the Request and wallet
                await _unitOfWork.WithdrawalRepository.UpdateAsync(request);
                await _unitOfWork.walletRepository.UpdateAsync(wallet);


                // Save it
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
