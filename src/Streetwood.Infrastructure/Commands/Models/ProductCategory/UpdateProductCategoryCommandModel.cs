using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.ProductCategory
{
    public class UpdateProductCategoryCommandModel : IRequest
    {
        public Guid Id { get; private set; }

        public string Name { get; set; }

        public string NameEng { get; set; }

        public UpdateProductCategoryCommandModel SetId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
