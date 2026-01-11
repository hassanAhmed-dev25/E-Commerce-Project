using System.Linq.Expressions;

namespace ECommerceProject.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task AddAsync(T entity);
        Task RemoveAsync(int id);
        void UpdateAsync(T entity);
    }
}
