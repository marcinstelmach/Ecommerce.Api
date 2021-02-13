namespace Streetwood.Infrastructure.Commands.Handlers.Slides
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Infrastructure.Commands.Models.Slides;

    public class UpdateSlideOrderIndexCommandHandler : IRequestHandler<UpdateSlideOrderIndexCommandModel>
    {
        private readonly ISlidesRepository slidesRepository;

        public UpdateSlideOrderIndexCommandHandler(ISlidesRepository slidesRepository)
        {
            this.slidesRepository = slidesRepository;
        }

        public async Task<Unit> Handle(UpdateSlideOrderIndexCommandModel request, CancellationToken cancellationToken)
        {
            var slide = await slidesRepository.GetAndEnsureExistAsync(request.Id);
            slide.SetOrderIndex(request.OrderIndex);

            await slidesRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}