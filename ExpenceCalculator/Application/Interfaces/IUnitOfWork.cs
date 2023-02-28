using ExpenceCalculator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceCalculator.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Operation> OperationRepository { get; }
        public IRepository<OperationGroup> OperationGroupRepository { get; }
    }
}
