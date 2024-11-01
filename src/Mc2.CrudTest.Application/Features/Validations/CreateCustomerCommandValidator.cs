using FluentValidation;
using Mc2.CrudTest.Application.Features.Commands;

namespace Mc2.CrudTest.Application.Features.Validations
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly IPhoneNumberValidator _phoneNumberValidator;

        public CreateCustomerCommandValidator(IPhoneNumberValidator phoneNumberValidator)
        {
            _phoneNumberValidator = phoneNumberValidator;

            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("First name must not exceed 100 characters.");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Last name must not exceed 100 characters.");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Must(BeAValidPhoneNumber).WithMessage("Invalid phone number.");

            RuleFor(c => c.RegionCode).Length(2).WithMessage("Region code length is not valid")
                .NotEmpty().WithMessage("Region code is required.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(c => c.BankAccountNumber)
                .NotEmpty().WithMessage("Bank account number is required.")
                .Must(BeAValidBankAccountNumber).WithMessage("Invalid bank account number.");
        }

        private bool BeAValidPhoneNumber(CreateCustomerCommand command, string phoneNumber)
        {
            return _phoneNumberValidator.IsValidPhoneNumber(phoneNumber, command.RegionCode);
        }

        private bool BeAValidBankAccountNumber(string bankAccountNumber)
        {

            return bankAccountNumber.Length >= 8 && bankAccountNumber.Length <= 20; 
        }
    }
}
