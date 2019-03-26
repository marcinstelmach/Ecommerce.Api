using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Order
{
    public class UpdateOrderCommandModel : IRequest
    {
        public int Id { get; protected set; }

        [Required]
        public bool Payed { get; set; }

        [Required]
        public bool Shipped { get; set; }

        [Required]
        public bool Closed { get; set; }

        public UpdateOrderCommandModel SetId(int id)
        {
            Id = id;
            return this;
        }
    }
}
