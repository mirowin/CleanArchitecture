using ExpenceCalculator.Application.Interfaces;
using ExpenceCalculator.Application.Queries;
using ExpenceCalculator.Domain;
using ExpenceCalculator.Domain.DTO;
using ExpenceCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceCalculator.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private DbContext context;
        private DbSet<T> dbSet;

        public Repository(DbContext dbContext)
        {
            this.context = dbContext;
            this.dbSet = context.Set<T>();
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> Get(GetOperationsQuery query)
        {
            return dbSet;
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
