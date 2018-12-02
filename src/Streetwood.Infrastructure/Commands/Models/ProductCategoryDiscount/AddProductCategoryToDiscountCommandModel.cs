using System;
using System.Collections.Generic;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.ProductCategoryDiscount
{
    public class AddProductCategoryToDiscountCommandModel : IRequest
    {
        public Guid DiscountId { get; protected set; }

        public IEnumerable<Guid> CategoryIds { get; set; }

        public AddProductCategoryToDiscountCommandModel SetId(Guid id)
        {
            DiscountId = id;
            return this;
        }
    }
}
