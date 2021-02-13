namespace Streetwood.Infrastructure.Commands.Handlers.Slides
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Core.Domain.Entities;
    using Streetwood.Infrastructure.Commands.Models.Slides;

    public class AddSlideCommandHandler : IRequestHandler<AddSlideCommandModel, Guid>
    {
        private readonly ISlidesRepository slidesRepository;

        public AddSlideCommandHandler(ISlidesRepository slidesRepository)
        {
            this.slidesRepository = slidesRepository;
        }

        public async Task<Guid> Handle(AddSlideCommandModel request, CancellationToken cancellationToken)
        {
            var lastSlideIndex = await slidesRepository.GetLastOrderIndexAsync();

            var slide = new Slide(lastSlideIndex + 1, request.Text, request.TextEng);
            slidesRepository.Add(slide);

            await slidesRepository.SaveChangesAsync();
            return slide.Id;
        }
    }
}