using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Email.Models
{
    public class SendNewOrderEmailCommandModel : IRequest
    {
        public int OrderId { get; }

        public SendNewOrderEmailCommandModel(int orderId)
        {
            OrderId = orderId;
        }
    }
}
