namespace Streetwood.Infrastructure.Commands.Models.Slides
{
    using System;
    using MediatR;

    public class AddSlideCommandModel : IRequest<Guid>
    {
        public string Text { get; set; }

        public string TextEng { get; set; }
    }
}