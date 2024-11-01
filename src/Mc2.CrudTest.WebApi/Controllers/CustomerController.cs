using Mc2.CrudTest.Application.Features.Commands;
using Mc2.CrudTest.Application.Features.Queries;
using Mc2.CrudTest.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CurdTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ICustomerDto> GetCustomer(Guid id, CancellationToken ct = default)
        {
            var query = new GetCustomerByIdQuery(id);

            var model = await _mediator.Send(query, ct);

            return model;
        }

        [HttpDelete]
        public async Task<ActionResult<Unit>> Delete(Guid id, CancellationToken ct = default)
        {
            return await _mediator.Send(new DeleteCustomerCommand(id), ct);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateCustomerCommand command, CancellationToken ct)
        {
            var result = await _mediator.Send(command, ct);

            return result;
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> Update(UpdateCustomerCommand command, CancellationToken ct)
        {
            var result = await _mediator.Send(command, ct);

            return result;
        }
    }
}
