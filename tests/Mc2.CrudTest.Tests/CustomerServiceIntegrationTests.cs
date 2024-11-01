using Mc2.CrudTest.Domain.DTOs;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.Services;
using Mc2.CrudTest.Domain.ValueObjects;
using Moq;

namespace Mc2.Tests
{
    public class CustomerServiceIntegrationTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly ICustomerService _customerService;
        public CustomerServiceIntegrationTests()
        {
            // Create a mock instance of the repository
            _mockCustomerRepository = new Mock<ICustomerRepository>();

            // Initialize the customer service with the mocked repository
            _customerService = new CustomerService(_mockCustomerRepository.Object);
        }
        [Fact]
        public async Task AddCustomer_ShouldSaveToDatabase()
        {
            // Arrange
            var command = new CustomerDto
            (
                Guid.Empty,
                "Vahid",
                "Asadi",
                 new DateTime(1990, 1, 1),
                 "+9812345678",
                 "Vahid.Asadi@gmail.com",
                 "12345676789"
            );

            // Act
            await _customerService.CreateCustomerAsync(command);

            // Assert that the AddAsync method was called exactly once
            _mockCustomerRepository.Verify(repo => repo.AddAsync(It.IsAny<Customer>()), Times.Once);

            // Assert that the SaveChangesAsync method was called exactly once
            _mockCustomerRepository.Verify(repo => repo.SaveChangeAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateCustomer_ShouldPersistChanges()
        {
            // Arrange

            var existingCustomer = new Customer
            (
                 "Vahid", "Asadi",
                 new DateTime(1990, 1, 1),
                 new PhoneNumber("+9812345678"),
                 new Email("Vahid.Asadi@gmail.com"),
                 new BankAccountNumber("12543456789")
            );



            // Set up the repository mock to return the existing customer
            _mockCustomerRepository
                .Setup(repo => repo.GetByIdAsync(existingCustomer.Id))
                .ReturnsAsync(existingCustomer);

            // Prepare the update command with new details
            var updateCommand = new CustomerDto
            (
                existingCustomer.Id,
                "Hamid",
                "Asadi",
                 new DateTime(1990, 1, 1),
                 "+9812345678",
                 "Hamid.Asadi@gmail.com",
                 "12347676589"
            );

            // Act
            await _customerService.UpdateCustomerAsync(updateCommand);

            // Assert

            // Verify that the repository's Update method was called with the updated customer
            _mockCustomerRepository.Verify(repo => repo.UpdateAsync(existingCustomer), Times.Once);
            _mockCustomerRepository.Verify(repo => repo.SaveChangeAsync(), Times.Once);
        }
    }


}