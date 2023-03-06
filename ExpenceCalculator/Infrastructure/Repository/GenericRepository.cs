//using ExpenceCalculator.Application.Interfaces;
//using ExpenceCalculator.Application.Queries;
//using ExpenceCalculator.Domain;
//using ExpenceCalculator.Domain.DTO;
//using ExpenceCalculator.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ExpenceCalculator.Infrastructure
//{
//    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
//    {
//        private DbContext context;
//        private DbSet<T> dbSet;

//        public GenericRepository(DbContext dbContext)
//        {
//            this.context = dbContext;
//            this.dbSet = context.Set<T>();
//        }

//        public void Delete(int id)
//        {
//            var entity = dbSet.Find(id);
//            if (entity != null)
//            {
//                Delete(entity);
//            }
//        }

//        public void Delete(T entity)
//        {
//            if (context.Entry(entity).State == EntityState.Detached)
//            {
//                dbSet.Attach(entity);
//            }

//            dbSet.Remove(entity);
//        }

//        public T Get(int id)
//        {
//            return dbSet.Find(id);
//        }

//        public IEnumerable<T> GetMany()
//        {
//            if (typeof(T) == typeof(Operation))
//            {
//                return dbSet.Include("Categories").Include("OperationDates");
//            }
//            dbSet.Load();
//            return dbSet;
//        }

//        public IEnumerable<T> GetMany(Func<T, bool> predicate)
//        {
//            var type = typeof(T);

//            if (type == typeof(Operation))
//            {
//                return dbSet.Include("Categories").Include("OperationDates").Where(predicate);
//            }

//            return dbSet.Where(predicate);
//        }

//        public IEnumerable<op> GetMany<op>(Func<op, bool> predicate) where op : Operation
//        {
//            return context.Set<op>().Where(predicate);
//        }

//        public void Insert(T entity)
//        {
//            dbSet.Add(entity);
//        }

//        public void Update(T entity)
//        {
//            dbSet.Update(entity);
//        }

//        public T Get(Func<T, bool> predicate)
//        {
//            return dbSet.FirstOrDefault(predicate);
//        }
//    }
//}
