using ExpenceCalculator.Domain;
using ExpenceCalculator.Domain.Entities;

namespace ExpenceCalculator.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Operation> OperationRepository { get; }
        public IRepository<T> GetRepository<T>() where T : BaseEntity;
        public void Save();
    }
}
