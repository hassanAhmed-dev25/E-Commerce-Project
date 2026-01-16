namespace ECommerceProject.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            
            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context);
            Carts = new CartRepository(_context);
            CartItems = new CartItemRepository(_context);

        }



        public ICategoryRepository Categories { get;}
        public IProductRepository Products  { get;}
        public ICartRepository Carts  { get;}
        public ICartItemRepository CartItems { get;}



        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
