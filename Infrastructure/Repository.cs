using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.DTO;

namespace CleanArchitecture.Infrastructure
{
    public class Repository<T> : IOperationRepository<Operation> where T : Operation
    {
        private List<Operation> operations = new List<Operation>()
        {
            new Operation() {
                Name = "Test 1",
                Id = 1,
                Type = OperationType.once,
                Value = 50,
                OperationDates = new DateTime[] { DateTime.Now }
            },

            new Operation() {
                Name = "Test 2",
                Id = 2,
                Type = OperationType.once,
                Value = 50,
                OperationDates = new DateTime[] { DateTime.Now.AddDays(1) }
            },
        };

        public bool DeleteOperation(int id)
        {
            throw new NotImplementedException();
        }

        public Operation GetOperation(int id)
        {
            return operations.FirstOrDefault(operation => operation.Id == id);
        }

        public IEnumerable<Operation> GetOperations(GetOperationsQuery query)
        {
            return operations;
        }

        public Operation InsertOperation(CreateOperationModel operationModel)
        {
            var operation = new Operation()
            {
                Name = operationModel.Name,
                OperationDates = operationModel.OperationTime,
                Type = operationModel.Type,
                Value = operationModel.Value,
                Id = GetUniqueId()
            };

            operations.Add(operation);
            return operation;
        }

        public bool UpdateOperation(Operation operation)
        {
            throw new NotImplementedException();
        }

        private int GetUniqueId()
        {
            return operations.Count + 1;
        }
    }
}
