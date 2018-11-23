using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.CharmCategory
{
    public class UpdateCharmCategoryCommandModel : IRequest
    {
        public Guid Id { get; protected set; }

        public string Name { get; set; }

        public string NameEng { get; set; }

        public UpdateCharmCategoryCommandModel SetId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
