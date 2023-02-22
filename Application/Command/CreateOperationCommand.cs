using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.DTO;
using MediatR;

namespace CleanArchitecture.Application.Command
{
    public class CreateOperationCommand : IRequest<Operation>
    {
        public CreateOperationModel Operation { get; set; }
    }

    public class CreateOperationCommandHandler : IRequestHandler<CreateOperationCommand, Operation>
    {
        private readonly IOperationRepository<Operation> _repository;

        public CreateOperationCommandHandler(IOperationRepository<Operation> repository)
        {
            _repository = repository;
        }

        public async Task<Operation> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            return _repository.InsertOperation(request.Operation);
        }
    }
}
