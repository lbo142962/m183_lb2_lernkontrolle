using Filmsammlung.Data;
using Filmsammlung.Model;
using System.Linq.Expressions;

namespace FilmSammlung.Tests
{
    public class GenericRepositoryTest : IGenericRepository
    {
        public void Delete<T>(T obj) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetByPredicate<T>(Expression<Func<T, bool>> predicate, params string[] include) where T : class
        {
            throw new NotImplementedException();
        }

        public void Insert<T>(T obj) where T : class
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T obj) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
