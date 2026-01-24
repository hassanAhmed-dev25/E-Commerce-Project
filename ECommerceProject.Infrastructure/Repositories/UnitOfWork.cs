using Microsoft.EntityFrameworkCore.Storage;

namespace ECommerceProject.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            
            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context);

            Carts = new CartRepository(_context);
            CartItems = new CartItemRepository(_context);

            Orders = new OrderRepository(_context);
            OrderItems = new OrderItemRepository(_context);
            ShippingAddresses = new ShippingAddressRepository(_context);

            walletRepository = new WalletRepository(_context);
            WithdrawalRepository = new WithdrawalRequestRepository(_context);

        }



        public ICategoryRepository Categories { get;}
        public IProductRepository Products  { get;}

        public ICartRepository Carts  { get;}
        public ICartItemRepository CartItems { get;}


        public IOrderRepository Orders  { get;}

        public IOrderItemRepository OrderItems { get; }

        public IShippingAddressRepository ShippingAddresses { get; }


        public IWalletRepository walletRepository { get; }

        public IWithdrawalRequestRepository WithdrawalRepository { get; }



        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }



        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction has not been started.");

            await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
                return;

            await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }



        
    }
}
