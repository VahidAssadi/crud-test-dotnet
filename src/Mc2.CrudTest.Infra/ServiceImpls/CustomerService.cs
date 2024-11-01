using Mc2.CrudTest.Domain.DTOs;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Services
{

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> CustomerExistsAsync(Guid id)
        {
            return await _customerRepository.GetByIdAsync(id) != null;
        }

        public async Task<Guid> CreateCustomerAsync(ICustomerDto customerDto)
        {
            var customer = new Customer(
                customerDto.FirstName, customerDto.LastName,
                customerDto.BirthDate,
                new PhoneNumber(customerDto.ContactNumber),
                new Email(customerDto.EmailAddress),
                new BankAccountNumber(customerDto.AccountNumber)
            );

            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveChangeAsync();
            return customer.Id;
        }

        public async Task UpdateCustomerAsync(ICustomerDto customerDto)
        {
            if (customerDto.CustomerId == Guid.Empty)
            {
                throw new ArgumentNullException("customer Id can not be null or empty");
            }
            var customer = await _customerRepository.GetByIdAsync(customerDto.CustomerId);

            if (customer is null)
            {
                throw new Exception("customer was not found");
            }
            customer.UpdateCustomer(customer.FirstName, customerDto.LastName, customerDto.BirthDate, 
                new PhoneNumber(customerDto.ContactNumber),
                new Email(customerDto.EmailAddress),
                new BankAccountNumber(customerDto.AccountNumber));

            await _customerRepository.UpdateAsync(customer);
            await _customerRepository.SaveChangeAsync();
        }
    }
}
