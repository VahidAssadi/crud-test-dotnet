using Mc2.CrudTest.Domain.Repositories;
using MediatR;

namespace Mc2.CrudTest.Application.Features.Commands
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand command, CancellationToken ct)
        {
            await _customerRepository.DeleteAsync(command.CustomerId);
            return Unit.Value;
        }
    }

}
