using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain;
using CleanArchitecture.Controllers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Queries
{
    public class GetOperationsQuery : IRequest<List<Operation>>
    {
    }

    public class GetOperationsHandler : IRequestHandler<GetOperationsQuery, List<Operation>>
    {
        private readonly IOperationRepository<Operation> _repository;

        public GetOperationsHandler(IOperationRepository<Operation> repository)
        {
            _repository = repository;
        }

        public async Task<List<Operation>> Handle(GetOperationsQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetOperations(request).ToList();
        }
    }
}
