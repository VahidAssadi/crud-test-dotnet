namespace Mc2.Tests
{
    using Mc2.CrudTest.Domain.Entities;
    using Mc2.CrudTest.Domain.ValueObjects;
    using System;
    using Xunit;

    public class CustomerUnitTests
    {
        [Fact]
        public void CreateCustomer_WithValidData_ShouldSucceed()
        {
            // Arrange
            //Act 

            var customer = CreateSampleCustomer();

            // Assert
            Assert.True(customer != null);
        }

        [Fact]
        public void UpdateCustomer_WithValidData_ShouldUpdateSuccessfully()
        {
            // Arrange
            var customer = CreateSampleCustomer();

            // Act
            customer.UpdateCustomer("Ali","Ahmadi", new DateTime(1990, 1, 1), 
                new PhoneNumber("+9812345678"),
                new Email("Vahid.Asadi@example.com"),
                new BankAccountNumber("154435456789"));

            // Assert
            Assert.Equal("Ali", customer.FirstName);
            Assert.Equal("Ahmadi", customer.LastName);
        }

        private Customer CreateSampleCustomer()
        {
            return new Customer(

                "Vahid", "Asadi",
                new DateTime(1990, 1, 1),
                new PhoneNumber("+9812345678"),
                new Email("Vahid.Asadi@example.com"),
                new BankAccountNumber("153523456789"));
        }

    }


}