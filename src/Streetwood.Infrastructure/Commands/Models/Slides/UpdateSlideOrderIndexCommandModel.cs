namespace Streetwood.Infrastructure.Commands.Models.Slides
{
    using System;
    using MediatR;

    public class UpdateSlideOrderIndexCommandModel : IRequest
    {
        public Guid Id { get; set; }

        public int OrderIndex { get; set; }
    }
}