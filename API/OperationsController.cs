using CleanArchitecture.Application.Command;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
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

            return Ok(result);
        }
    }
}
