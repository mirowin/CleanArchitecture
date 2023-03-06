using ExpenceCalculator.Application.Command;
using ExpenceCalculator.Application.Queries;
using ExpenceCalculator.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenceCalculator.Controllers
{
    [ApiController]
    [Route("api")]
    public class OperationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OperationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Operations")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetOperationsQuery());

            return Ok(result);
        }

        [HttpGet("Operation/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetOperationByIdQuery() { Id = id});

            return Ok(result);
        }

        [HttpPost("Operation/Add")]
        public async Task<IActionResult> Add([FromBody] CreateOperationModel model)
        {
            var result = await _mediator.Send(new CreateOperationCommand()
            {
                Operation = model
            });

            var viewModel = new OperationViewModel()
            {
                Name = model.Name,
                Value = model.Value,
                Type = model.Type,
                Categories = model.OperationGroup,
                OperationDates = model.OperationTime
            };

            return Ok(viewModel);
        }
    }
}
