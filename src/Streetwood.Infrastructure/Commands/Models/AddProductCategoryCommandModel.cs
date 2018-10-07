using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models
{
    public class AddProductCategoryCommandModel : IRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string NameEng { get; set; }

        public Guid? ProductCategoryId { get; set; }
    }
}
