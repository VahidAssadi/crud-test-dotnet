using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Entities
{


    public class Customer
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public PhoneNumber ContactNumber { get; private set; }
        public Email EmailAddress { get; private set; }
        public BankAccountNumber AccountNumber { get; private set; }

        protected Customer() { } // for ef
        public Customer(string firstName, string lastName, DateTime birthDate, PhoneNumber contactNumber, Email emailAddress, BankAccountNumber accountNumber)
        {
            Id = Guid.NewGuid();
            FirstName = string.IsNullOrWhiteSpace(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            LastName = string.IsNullOrWhiteSpace(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
            BirthDate = birthDate >= DateTime.Now ? throw new ArgumentException(nameof(birthDate)) : birthDate;
            ContactNumber = contactNumber ?? throw new ArgumentNullException(nameof(contactNumber));
            EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
        }


        // Update methods
        public void UpdateCustomer(string firstName, string lastName, DateTime birthDate, PhoneNumber contactNumber, Email emailAddress, BankAccountNumber accountNumber)
        {
            FirstName = string.IsNullOrWhiteSpace(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            LastName = string.IsNullOrWhiteSpace(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
            BirthDate = birthDate >= DateTime.Now ? throw new ArgumentException(nameof(birthDate)) : birthDate;
            ContactNumber = contactNumber ?? throw new ArgumentNullException(nameof(contactNumber));
            EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
        }

    }
}
