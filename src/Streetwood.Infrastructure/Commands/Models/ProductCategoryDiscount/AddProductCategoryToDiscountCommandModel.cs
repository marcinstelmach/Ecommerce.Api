using System;
using System.Collections.Generic;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.ProductCategoryDiscount
{
    public class AddProductCategoryToDiscountCommandModel : IRequest
    {
        public Guid DiscountId { get; set; }

        public IEnumerable<Guid> CategoryIds { get; set; }
    }
}
