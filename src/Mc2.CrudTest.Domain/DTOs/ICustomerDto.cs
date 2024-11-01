namespace Mc2.CrudTest.Domain.DTOs
{
    public interface ICustomerDto
    {
        public Guid CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public string ContactNumber { get; }
        public string EmailAddress { get; }
        public string AccountNumber { get; }
    }

    public class CustomerDto : ICustomerDto
    {
        public CustomerDto(Guid customerId, string firstName, string lastName, DateTime birthDate, string contactNumber, string emailAddress, string accountNumber)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            AccountNumber = accountNumber;
        }

        public Guid CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";
        public DateTime BirthDate { get; }
        public string ContactNumber { get; }
        public string EmailAddress { get; }
        public string AccountNumber { get; }
    }
}
