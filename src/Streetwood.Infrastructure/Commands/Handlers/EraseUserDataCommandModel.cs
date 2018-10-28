using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Handlers
{
    public class EraseUserDataCommandModel : IRequest
    {
        public Guid Id { get; set; }

        public EraseUserDataCommandModel(Guid id)
        {
            Id = id;
        }
    }
}
