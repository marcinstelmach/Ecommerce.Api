using System;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.ProductCategoryDiscount
{
    public class GetProductCategoryDiscountQueryModel : IRequest<ProductCategoryDiscountWithDataDto>
    {
        public Guid Id { get; protected set; }

        public GetProductCategoryDiscountQueryModel(Guid id)
        {
            Id = id;
        }
    }
}
