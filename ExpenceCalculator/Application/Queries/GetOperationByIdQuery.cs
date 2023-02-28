using ExpenceCalculator.Application.Interfaces;
using ExpenceCalculator.Domain;
using ExpenceCalculator.Domain.Entities;
using MediatR;

namespace ExpenceCalculator.Application.Queries
{
    public class GetOperationByIdQuery : IRequest<Operation>
    {
        public int Id { get; set; }
    }

    public class GetOperationByIdQueryHandler : IRequestHandler<GetOperationByIdQuery, Operation>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetOperationByIdQueryHandler(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public async Task<Operation> Handle(GetOperationByIdQuery request, CancellationToken cancellationToken)
        {
            return unitOfWork.OperationRepository.Get(request.Id);
        }
    }
}
