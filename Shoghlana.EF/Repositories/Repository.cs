using Microsoft.EntityFrameworkCore;
using Shoghlana.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDBContext Context;

        public Repository(ApplicationDBContext _context)
        {
            Context = _context;
        }


        public List<T> GetAll(string include = null) 
        {
            if (include == null)
            {
                return Context.Set<T>().ToList();
            }
            return Context.Set<T>().Include(include).ToList();
        }

        public T GetById(int? Id) 
        {
            return Context.Set<T>().Find(Id);
        }

        public List<T> Get(Func<T, bool> where) 
        {
            return Context.Set<T>().Where(where).ToList();
        }

        public void Insert(T item) 
        {
            Context.Add(item);
        }

        public void Update(T item) 
        {
            Context.Update(item);
        }

        public void Delete(T item)
        {
            Context.Remove(item);
        }

        public void Save() 
        {
            Context.SaveChanges();
        }

    }
}
