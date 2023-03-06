using ExpenceCalculator.Application.Interfaces;
using ExpenceCalculator.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceCalculator.Infrastructure.Repository
{
    public class BaseGenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private DbContext context;
        private DbSet<T> dbSet;

        public BaseGenericRepository(DbContext dbContext)
        {
            this.context = dbContext;
            this.dbSet = context.Set<T>();
        }

        public virtual void Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public virtual void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public virtual T Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetMany()
        {
            dbSet.Load();
            return dbSet;
        }

        public virtual IEnumerable<T> GetMany(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public virtual T Get(Func<T, bool> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }
    }
}
