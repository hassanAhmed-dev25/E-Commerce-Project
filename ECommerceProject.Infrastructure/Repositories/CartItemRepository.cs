using System.Linq.Expressions;

namespace ECommerceProject.Infrastructure.Repositories
{
    internal class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IQueryable<CartItem> _dbSet;
        public CartItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<CartItem>();
        }

        public async Task<bool> AnyAsync(Expression<Func<CartItem, bool>> filter)
        {
            IQueryable<CartItem> query = _dbSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            return await query.AnyAsync();

        }
    }
}
