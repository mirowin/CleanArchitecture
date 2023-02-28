using ExpenceCalculator.Application.Interfaces;
using ExpenceCalculator.Domain.Entities;
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
        private IRepository<OperationGroup> operationGroupRepository;

        public IRepository<Operation> OperationRepository { get
            {
                if (operationRepository == null)
                {
                    operationRepository = new Repository<Operation>(context);
                }

                return operationRepository;
            } 
        }

        public IRepository<OperationGroup> OperationGroupRepository { get
            {
                if (operationGroupRepository == null)
                {
                    operationGroupRepository = new Repository<OperationGroup>(context);
                }

                return operationGroupRepository;
            } 
        }

        public UnitOfWork(ApplicationContext context) 
        { 
            this.context = context;
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
