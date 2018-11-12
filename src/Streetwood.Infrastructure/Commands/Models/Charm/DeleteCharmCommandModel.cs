using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Charm
{
    public class DeleteCharmCommandModel : IRequest
    {
        public Guid Id { get; protected set; }

        public DeleteCharmCommandModel(Guid id)
        {
            Id = id;
        }
    }
}
