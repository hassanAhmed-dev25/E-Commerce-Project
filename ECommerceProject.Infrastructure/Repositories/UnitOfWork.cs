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

        }



        public ICategoryRepository Categories { get;}
        public IProductRepository Products  { get;}




        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
