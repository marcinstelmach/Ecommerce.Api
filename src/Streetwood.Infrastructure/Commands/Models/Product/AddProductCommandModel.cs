using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Streetwood.Infrastructure.Dto;

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

        public bool AcceptCharms { get; set; }

        public bool AcceptGraver { get; set; }

        [Required]
        public int MaxCharmCount { get; set; }

        public string Sizes { get; set; }

        [Required]
        public Guid ProductCategoryId { get; set; }

        public ICollection<ProductColorDto> ProductColors { get; set; }
    }
}
