using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Product
{
    public class DeleteImageCommandModel : IRequest
    {
        public Guid Id { get; protected set; }

        public DeleteImageCommandModel(Guid id)
        {
            Id = id;
        }
    }
}
