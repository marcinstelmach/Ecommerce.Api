using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Charm
{
    public class UpdateCharmCommandModel : IRequest
    {
        public Guid Id { get; protected set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string NameEng { get; set; }

        [Required]
        [RegularExpression("^\\d{0,8}(\\.\\d{1,2})?$")]
        public decimal Price { get; set; }

        public UpdateCharmCommandModel SetId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
