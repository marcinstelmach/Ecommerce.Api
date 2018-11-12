using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.ProductCategory
{
    public class DeleteProductCategoryCommandModel : IRequest
    {
        public Guid Id { get; protected set; }

        public DeleteProductCategoryCommandModel(Guid id)
        {
            Id = id;
        }
    }
}
