using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Order
{
    public class UpdateOrderCommandModel : IRequest
    {
        public int Id { get; protected set; }

        public bool Payed { get; set; }

        public bool Shipped { get; set; }

        public bool Closed { get; set; }

        public UpdateOrderCommandModel SetId(int id)
        {
            Id = id;
            return this;
        }
    }
}
