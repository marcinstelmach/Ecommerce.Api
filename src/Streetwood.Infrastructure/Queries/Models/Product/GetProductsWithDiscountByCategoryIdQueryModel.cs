using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Product
{
    public class GetProductsWithDiscountByCategoryIdQueryModel : IRequest<IList<ProductWithDiscountDto>>
    {
        public Guid CategoryId { get; protected set; }

        public GetProductsWithDiscountByCategoryIdQueryModel(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
