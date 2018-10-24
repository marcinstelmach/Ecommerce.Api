using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models
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
