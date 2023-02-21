using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Queries
{
    public class GetOperationByIdQuery : IRequest<Operation>
    {
        public int Id { get; set; }
    }

    public class GetOperationByIdQueryHandler : IRequestHandler<GetOperationByIdQuery, Operation>
    {
        private readonly IOperationRepository<Operation> _repository;

        public GetOperationByIdQueryHandler(IOperationRepository<Operation> repository)
        {
            _repository = repository;
        }

        public async Task<Operation> Handle(GetOperationByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetOperation(request.Id);
        }
    }
}
