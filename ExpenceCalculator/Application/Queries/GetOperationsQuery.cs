using ExpenceCalculator.Application.Interfaces;
using ExpenceCalculator.Domain;
using ExpenceCalculator.Domain.DTO;
using ExpenceCalculator.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenceCalculator.Application.Queries
{
    public class GetOperationsQuery : IRequest<IEnumerable<OperationViewModel>>
    {
    }

    public class GetOperationsHandler : IRequestHandler<GetOperationsQuery, IEnumerable<OperationViewModel>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetOperationsHandler(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public async Task<IEnumerable<OperationViewModel>> Handle(GetOperationsQuery request, CancellationToken cancellationToken)
        {
            var operations = unitOfWork.OperationRepository.GetMany();

            return operations.Select(x =>
                    new OperationViewModel()
                    {
                        Name = x.Name,
                        Value = x.Value,
                        Type = x.Type,
                        OperationDates = x.OperationDates.Select(d => new OperationDateViewModel() { Date = d.Date }),
                        Categories = x.Categories.Select(o => new CategoryViewModel() { Name = o.Name })
                    });
        }
    }
}
