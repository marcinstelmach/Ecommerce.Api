using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models
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
