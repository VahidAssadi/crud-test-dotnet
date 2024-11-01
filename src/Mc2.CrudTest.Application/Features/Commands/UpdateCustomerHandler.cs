using Mc2.CrudTest.Domain.DTOs;
using Mc2.CrudTest.Domain.Services;
using MediatR;

namespace Mc2.CrudTest.Application.Features.Commands
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerService _customerService;

        public UpdateCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand command, CancellationToken ct)
        {
            await _customerService.UpdateCustomerAsync(new CustomerDto(command.CustomerId,
                command.FirstName,
                command.LastName,
                command.DateOfBirth,
                command.PhoneNumber,
                command.Email,
                command.BankAccountNumber));
            
            return Unit.Value;
        }
    }


}
