using MediatR;

namespace Mc2.CrudTest.Application.Features.Commands
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public Guid CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string BankAccountNumber { get; }

        public UpdateCustomerCommand(Guid customerId, string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }
    }

}
