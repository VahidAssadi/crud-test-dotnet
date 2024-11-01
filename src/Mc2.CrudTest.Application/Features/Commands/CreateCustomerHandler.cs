using FluentValidation;
using Mc2.CrudTest.Domain.DTOs;
using Mc2.CrudTest.Domain.Services;
using MediatR;

namespace Mc2.CrudTest.Application.Features.Commands
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerService _customerService;
        private readonly IValidator<CreateCustomerCommand> _validator;
        public CreateCustomerHandler(ICustomerService customerService,
            IValidator<CreateCustomerCommand> validator)
        {
            _customerService = customerService;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateCustomerCommand command, CancellationToken ct)
        {

            //var validationResult = await _validator.ValidateAsync(command, ct);
            //if (!validationResult.IsValid)
            //{
            //    var errors = validationResult.Errors.Select(p => p.ErrorMessage);

            //    throw new ValidationException(string.Join(",", errors));
            //}
            var customerId = await _customerService.CreateCustomerAsync(new CustomerDto(Guid.Empty, command.FirstName, command.LastName,
                command.DateOfBirth,
                command.PhoneNumber,
                command.Email,
                command.BankAccountNumber));

            return customerId;
        }
    }

}
