using MediatR;

namespace Mc2.CrudTest.Application.Features.Commands
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public Guid CustomerId { get; }

        public DeleteCustomerCommand(Guid customerId)
        {
            CustomerId = customerId;
        }
    }


}
