using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Product
{
    public class AddProductCommandModel : IRequest
    {
        public string Name { get; set; }

        public string NameEng { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string DescriptionEng { get; set; }

        public bool AcceptCharms { get; set; }

        public string Sizes { get; set; }

        public Guid ProductCategoryId { get; set; }
    }
}
