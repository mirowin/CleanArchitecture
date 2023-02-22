using CleanArchitecture.Application.Queries;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.DTO;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IOperationRepository<T> where T : Operation
    {
        public IEnumerable<T> GetOperations(GetOperationsQuery query);
        public T GetOperation(int id);
        public bool DeleteOperation(int id);
        public bool UpdateOperation(T operation);
        public T InsertOperation(CreateOperationModel operation);
    }
}
