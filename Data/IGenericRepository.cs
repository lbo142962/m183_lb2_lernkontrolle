using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Filmsammlung.Data
{
    public interface IGenericRepository
    {
        public IEnumerable<T> GetAll<T>() where T : class;
        public Task<List<T>> GetByPredicate<T>(Expression<Func<T, bool>> predicate, params string[] include) where T : class;
        public T GetById<T>(int id) where T : class;
        public void Insert<T>(T obj) where T : class;
        public void Update<T>(T obj) where T : class;
        public void Delete<T>(T obj) where T : class;
        public void Save();
    }
}
