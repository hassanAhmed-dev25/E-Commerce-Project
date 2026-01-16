using System.Linq.Expressions;

namespace ECommerceProject.Application.Interfaces
{
    public interface ICartItemRepository : IRepository<CartItem>
    {

        Task<bool> AnyAsync(Expression<Func<CartItem, bool>> filter);

    }
}
