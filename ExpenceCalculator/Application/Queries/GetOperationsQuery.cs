using ExpenceCalculator.Application.Interfaces;
using ExpenceCalculator.Domain;
using ExpenceCalculator.Domain.Entities;
using MediatR;

namespace ExpenceCalculator.Application.Queries
{
    public class GetOperationsQuery : IRequest<List<Operation>>
    {
    }

    public class GetOperationsHandler : IRequestHandler<GetOperationsQuery, List<Operation>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetOperationsHandler(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public async Task<List<Operation>> Handle(GetOperationsQuery request, CancellationToken cancellationToken)
        {
            return unitOfWork.OperationRepository.Get(request).ToList();
        }
    }
}
