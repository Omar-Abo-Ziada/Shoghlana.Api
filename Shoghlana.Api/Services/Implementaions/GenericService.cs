using Shoghlana.Api.Services.Interfaces;
using Shoghlana.Core.Interfaces;
using System.Linq.Expressions;

namespace Shoghlana.Api.Services.Implementations
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IGenericRepository<T> _repository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        //******************************************************

        public virtual T Get(int id)
        {
            return _repository.GetById(id);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        //------------------------------------------------------

        public virtual T Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            return _repository.Find(criteria, includes);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            return await _repository.FindAsync(criteria, includes);
        }

        //------------------------------------------------------

        public virtual IEnumerable<T> FindAll(string[] includes = null, Expression<Func<T, bool>> criteria = null)
        {
            return _repository.FindAll(includes, criteria);
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync(string[] includes = null, Expression<Func<T, bool>> criteria = null)
        {
            return await _repository.FindAllAsync(includes, criteria);
        }

        //------------------------------------------------------

        public virtual T Add(T entity)
        {
            var result = _repository.Add(entity);
            _unitOfWork.Save();
            return result;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var result = await _repository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return result;
        }


        public virtual IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            var result = _repository.AddRange(entities);
            _unitOfWork.Save();
            return result;
        }

        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            var result = await _repository.AddRangeAsync(entities);
            await _unitOfWork.SaveAsync();
            return result;
        }

        //------------------------------------------------------


        public virtual T Update(T entity)
        {
            var result = _repository.Update(entity);
            _unitOfWork.Save();
            return result;
        }

        //------------------------------------------------------

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Save();
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            _repository.DeleteRange(entities);
            _unitOfWork.Save();
        }

        //------------------------------------------------------

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}