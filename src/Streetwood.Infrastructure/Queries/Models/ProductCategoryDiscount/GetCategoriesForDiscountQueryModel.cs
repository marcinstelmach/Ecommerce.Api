using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.ProductCategoryDiscount
{
    public class GetCategoriesForDiscountQueryModel : IRequest<IList<ProductsCategoriesForDiscountDto>>
    {
        public Guid Id { get; protected set; }

        public GetCategoriesForDiscountQueryModel(Guid id)
        {
            Id = id;
        }
    }
}
