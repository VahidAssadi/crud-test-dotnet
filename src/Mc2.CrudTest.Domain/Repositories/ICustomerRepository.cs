using Mc2.CrudTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<Customer?> GetByIdAsync(Guid id);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);

        Task SaveChangeAsync();
    }
}
