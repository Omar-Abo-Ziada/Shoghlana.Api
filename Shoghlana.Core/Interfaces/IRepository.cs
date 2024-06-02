using Shoghlana.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();

        public Task<IEnumerable<T>> GetAllAsync();

        public T GetById(int id);

        public Task<T> GetByIdAsync(int id);

        public bool IsValid(int id);

        public Task<bool> IsValidAsync(int id);

        public T Find(string[] includes = null, Expression<Func<T, bool>> criteria = null);

        public Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

        public IEnumerable<T> FindAll(string[] includes = null , Expression<Func<T, bool>> criteria = null) ;

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int skip, int take);

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take,
       Expression<Func<T, object>> orderBy = null, OrderWay orderByDirection = OrderWay.Ascending);

        public Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

        public Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip);

        public Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
           Expression<Func<T, object>> orderBy = null, OrderWay orderByDirection = OrderWay.Ascending);

        public T Add(T entity);

        public Task<T> AddAsync(T entity);

        public IEnumerable<T> AddRange(IEnumerable<T> entities);

        public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        public T Update(T entity);

        public void Delete(T entity);

        public void DeleteRange(IEnumerable<T> entities);

        public void Attach(T entity);

        public void AttachRange(IEnumerable<T> entities);

        public int Count();

        public int Count(Expression<Func<T, bool>> criteria);

        public Task<int> CountAsync();

        public Task<int> CountAsync(Expression<Func<T, bool>> criteria);

    }
}
