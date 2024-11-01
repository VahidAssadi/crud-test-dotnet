using Mc2.CrudTest.Domain.DTOs;
using MediatR;

namespace Mc2.CrudTest.Application.Features.Queries
{
    public class GetCustomerByIdQuery : IRequest<ICustomerDto>
    {
        public Guid CustomerId { get; }

        public GetCustomerByIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }

}
