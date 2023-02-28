using ExpenceCalculator.Application.Interfaces;
using ExpenceCalculator.Domain;
using ExpenceCalculator.Domain.DTO;
using ExpenceCalculator.Domain.Entities;
using ExpenceCalculator.Infrastructure.Common.Extentions;
using MediatR;

namespace ExpenceCalculator.Application.Command
{
    public class CreateOperationCommand : IRequest<Operation>
    {
        public CreateOperationModel Operation { get; set; }
    }

    public class CreateOperationCommandHandler : IRequestHandler<CreateOperationCommand, Operation>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreateOperationCommandHandler(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        public async Task<Operation> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            var operation = new Operation()
            {
                Name = request.Operation.Name,
                Value = request.Operation.Value,
                OperationDates = request.Operation.OperationTime.Select(x => x.CreateOpeationDate()),
                Type = request.Operation.Type
            };
            unitOfWork.OperationRepository.Insert(operation);
            return operation;
        }
    }
}
