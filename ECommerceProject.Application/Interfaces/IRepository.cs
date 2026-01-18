using System.Linq.Expressions;

namespace ECommerceProject.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IQueryable<T>>? include = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null);
        Task<IEnumerable<T>> GetAllWithAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        Task RemoveAsync(int id);
        Task UpdateAsync(T entity);
    }
}
