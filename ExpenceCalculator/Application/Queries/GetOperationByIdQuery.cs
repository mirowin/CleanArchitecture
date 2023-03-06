using ExpenceCalculator.Application.Interfaces;
using ExpenceCalculator.Domain.DTO;
using ExpenceCalculator.Domain.Entities;
using MediatR;

namespace ExpenceCalculator.Application.Queries
{
    public class GetOperationByIdQuery : IRequest<OperationViewModel>
    {
        public int Id { get; set; }
    }

    public class GetOperationByIdQueryHandler : IRequestHandler<GetOperationByIdQuery, OperationViewModel>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetOperationByIdQueryHandler(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public async Task<OperationViewModel> Handle(GetOperationByIdQuery request, CancellationToken cancellationToken)
        {
            var operation = unitOfWork.OperationRepository.Get(request.Id);

            var viewModel = new OperationViewModel()
            {
                Name = operation.Name,
                Value = operation.Value,
                Type = operation.Type,
                OperationDates = operation.OperationDates.Select(d => new OperationDateViewModel() { Date = d.Date }),
                Categories = operation.Categories.Select(o => new CategoryViewModel() { Name = o.Name })
            };
            return viewModel;
        }
    }
}
