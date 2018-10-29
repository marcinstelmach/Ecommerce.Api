using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.CharmCategory
{
    public class DeleteCharmCategoryCommandModel : IRequest
    {
        public Guid Id { get; set; }

        public DeleteCharmCategoryCommandModel(Guid id)
        {
            Id = id;
        }
    }
}
