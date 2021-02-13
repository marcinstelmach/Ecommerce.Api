namespace Streetwood.Infrastructure.Commands.Models.Slides
{
    using System;
    using MediatR;

    public class DeleteSlideCommandModel : IRequest
    {
        public DeleteSlideCommandModel(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}