using System.Linq.Expressions;

namespace TestTask.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", bool isTracking = true);
        void Delete(T entity);
        void Update(T entity);
    }
}
