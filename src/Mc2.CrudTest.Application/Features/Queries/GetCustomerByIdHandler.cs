using Mc2.CrudTest.Domain.DTOs;
using Mc2.CrudTest.Domain.Repositories;
using MediatR;

namespace Mc2.CrudTest.Application.Features.Queries
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, ICustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<ICustomerDto> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(query.CustomerId);
            if (customer == null) return null;

            return new CustomerDto(customer.Id,
                customer.FirstName, customer.LastName,
                customer.BirthDate,
                customer.ContactNumber.Number,
                customer.EmailAddress.Address,
                customer.AccountNumber.AccountNumber);

        }
    }

}
