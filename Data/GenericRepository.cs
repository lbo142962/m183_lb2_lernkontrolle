using FilmSammlung;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Filmsammlung.Data
{
    public class GenericRepository : IGenericRepository
    {
        private readonly NotenContext _context;
        public GenericRepository(NotenContext notenContext)
        {
            this._context = notenContext;
        }
        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }
        public T GetById<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }
        public void Insert<T>(T obj) where T : class
        {
            _context.Add(obj);
            Save();
        }
        public void Update<T>(T obj) where T : class
        {
            _context.Update(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete<T>(T obj) where T : class
        {
            _context.Set<T>().Remove(obj);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private IQueryable<T> AttachIncludes<T>(IQueryable<T> query, params string[] include) where T : class
        {
            if (include == null || include.Length <= 0)
            {
                return query;
            }
            //if (include.Length == 1)
            //{
            //    query.Include(include[0]);
            //}

            int length = include.Length;
            for (int i = 0; i < length; i++)
            {
                query = query.Include(include[i]);
            }

            return query;
        }
        public async Task<List<T>> GetByPredicate<T>(Expression<Func<T, bool>> predicate, params string[] include) where T : class
        {
            IQueryable<T> ListToCheck = _context.Set<T>(); //.AsQueryable();
            IQueryable<T> query = AttachIncludes(ListToCheck, include);
            query = query.Where(predicate);
            return query.ToList();
        }
        // Weitere nützliche Methoden sind, Exist, AddorUpdate nach ID ob 0 oder nicht, 
    }
}
