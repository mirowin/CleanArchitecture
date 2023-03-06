using ExpenceCalculator.Application.Interfaces;
using ExpenceCalculator.Domain;
using ExpenceCalculator.Domain.DTO;
using ExpenceCalculator.Domain.Entities;
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
                OperationDates = request.Operation.OperationTime.Select(x => new OperationDate(x.Date)).ToList(),
                Type = request.Operation.Type
            };

            unitOfWork.GetRepository<Operation>().Insert(operation);

            var categories = new List<Category>();
            foreach (var categoryName in request.Operation.OperationGroup)
            {
                var category = unitOfWork.GetRepository<Category>().Get(x => x.Name == categoryName.Name);

                if (category == default)
                {
                    category = new Category(categoryName.Name);
                    unitOfWork.GetRepository<Category>().Insert(category);
                }
                categories.Add(category);
            }

            operation.Categories = categories;

            unitOfWork.Save();
            return operation;
        }
    }
}
