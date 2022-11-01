using Brainbox.Domain.Data;
using Brainbox.Domain.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brainbox.Domain.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BrainboxDBContext _db;
        internal DbSet<T> dbSet;

        public Repository(BrainboxDBContext db)
        {
            _db = db;
            this.dbSet=_db.Set<T>();
        }

        public bool Add(T entity, Expression<Func<T, bool>> filter)
        {
            var alreadyExists = dbSet.Where(filter);
            if (!alreadyExists.Any())
            {
                dbSet.Add(entity);
                return false;
            }
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
