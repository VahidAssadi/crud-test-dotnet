using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Features.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string RegionCode { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public CreateCustomerCommand(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber,string regionCode, string email, string bankAccountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            RegionCode = regionCode;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }
    }
}
