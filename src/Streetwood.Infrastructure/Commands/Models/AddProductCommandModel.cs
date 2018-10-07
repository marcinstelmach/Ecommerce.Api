using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models
{
    public class AddProductCommandModel : IRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string NameEng { get; set; }

        [Required]
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
