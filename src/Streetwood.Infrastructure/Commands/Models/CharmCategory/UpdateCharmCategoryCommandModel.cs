using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.CharmCategory
{
    public class UpdateCharmCategoryCommandModel : IRequest
    {
        public Guid Id { get; protected set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string NameEng { get; set; }

        public UpdateCharmCategoryCommandModel SetId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
