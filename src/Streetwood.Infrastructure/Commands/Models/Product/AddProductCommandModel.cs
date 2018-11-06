using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Product
{
    public class AddProductCommandModel : IRequest<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string NameEng { get; set; }

        [Required]
        [RegularExpression("^\\d{0,8}(\\.\\d{1,2})?$")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string DescriptionEng { get; set; }

        [Required]
        public bool AcceptCharms { get; set; }

        public string Sizes { get; set; }

        [Required]
        public Guid ProductCategoryId { get; set; }
    }
}
