using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll(string include = null);
        public T GetById(int? Id);
        public List<T> Get(Func<T, bool> where);
        public void Insert(T item);
        public void Update(T item);
        public void Delete(T item);
        public void Save();








    }
}
