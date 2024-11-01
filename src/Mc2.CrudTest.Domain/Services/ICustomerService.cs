using Mc2.CrudTest.Domain.DTOs;

namespace Mc2.CrudTest.Domain.Services
{
    public interface ICustomerService
    {
        Task<Guid> CreateCustomerAsync(ICustomerDto customerDto);
        Task UpdateCustomerAsync(ICustomerDto customerDto);
    }
}
