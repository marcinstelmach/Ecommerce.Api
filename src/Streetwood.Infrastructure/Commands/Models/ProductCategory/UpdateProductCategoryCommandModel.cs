using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.ProductCategory
{
    public class UpdateProductCategoryCommandModel : IRequest
    {
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string NameEng { get; set; }

        public UpdateProductCategoryCommandModel SetId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
