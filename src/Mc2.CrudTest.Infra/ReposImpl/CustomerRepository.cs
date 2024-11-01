using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Infra.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infra.ReposImpl
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByIdAsync(Guid customerId)
        {
            try
            {
                return await _context.Customers.SingleOrDefaultAsync(p => p.Id == customerId);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task AddAsync(Customer customer)
        {
            try
            {
                await _context.Customers.AddAsync(customer);
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public async Task DeleteAsync(Guid customerId)
        {
            var customer = await GetByIdAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
        }


        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
