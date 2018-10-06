using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Product
{
    public class GetProductsByCategoryIdQueryModel : IRequest<IList<ProductDto>>
    {
        public Guid CategoryId { get; set; }

        public GetProductsByCategoryIdQueryModel(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
