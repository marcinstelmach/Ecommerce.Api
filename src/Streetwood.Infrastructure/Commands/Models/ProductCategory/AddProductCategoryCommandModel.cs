using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.ProductCategory
{
    public class AddProductCategoryCommandModel : IRequest
    {
        public string Name { get; set; }

        public string NameEng { get; set; }

        public Guid? ProductCategoryId { get; set; }
    }
}
