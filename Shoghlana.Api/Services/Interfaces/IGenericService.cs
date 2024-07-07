using System.Linq.Expressions;

namespace Shoghlana.Api.Services.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        T Get(int id);

        Task<T> GetAsync(int id);

        //----------------------------------------------------------------

        T Find(Expression<Func<T, bool>> criteria, string[] includes = null);

        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

        //----------------------------------------------------------------

        IEnumerable<T> FindAll(string[] includes = null, Expression<Func<T, bool>> criteria = null);

        Task<IEnumerable<T>> FindAllAsync(string[] includes = null, Expression<Func<T, bool>> criteria = null);

        //----------------------------------------------------------------

        T Add(T entity);

        Task<T> AddAsync(T entity);

        //----------------------------------------------------------------

        IEnumerable<T> AddRange(IEnumerable<T> entities);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        //----------------------------------------------------------------

        T Update(T entity);

        //----------------------------------------------------------------

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        //----------------------------------------------------------------

        void Save();
    }
}