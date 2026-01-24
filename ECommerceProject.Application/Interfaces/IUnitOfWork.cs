namespace ECommerceProject.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }

        ICartRepository Carts { get; }
        ICartItemRepository CartItems { get; }

        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        IShippingAddressRepository ShippingAddresses { get; }

        IWalletRepository walletRepository { get; }
        IWithdrawalRequestRepository WithdrawalRepository { get; }




        // Transaction Methods
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();


        Task SaveChangesAsync();

    }
}
