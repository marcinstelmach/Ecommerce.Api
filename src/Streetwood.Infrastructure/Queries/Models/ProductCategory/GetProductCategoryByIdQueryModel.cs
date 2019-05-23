using System;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.ProductCategory
{
    public class GetProductCategoryByIdQueryModel : IRequest<ProductCategoryDto>
    {
        public Guid Id { get; set; }

        public GetProductCategoryByIdQueryModel(Guid id)
        {
            Id = id;
        }
    }
}
