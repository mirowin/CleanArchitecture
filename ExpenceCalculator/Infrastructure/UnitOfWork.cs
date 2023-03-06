using ExpenceCalculator.Application.Interfaces;
using ExpenceCalculator.Domain;
using ExpenceCalculator.Domain.Entities;
using ExpenceCalculator.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceCalculator.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        private DbContext context;
        private IRepository<Operation> operationRepository;

        public IRepository<Operation> OperationRepository
        {
            get
            {
                if (operationRepository == null)
                {
                    operationRepository = new OperationRepository(context);
                }
                return operationRepository;
            }
        }

        public UnitOfWork(ApplicationContext context) 
        { 
            this.context = context;
        } 

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new BaseGenericRepository<T>(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
