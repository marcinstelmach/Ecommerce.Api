using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models
{
    public class AddProductCategoryToDiscountCommandModel : IRequest
    {
        public Guid CategoryId { get; set; }

        public Guid DiscountId { get; set; }
    }
}
