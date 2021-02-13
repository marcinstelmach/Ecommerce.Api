namespace Streetwood.Infrastructure.Commands.Handlers.Slides
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Infrastructure.Commands.Models.Slides;
    using Streetwood.Infrastructure.Managers.Abstract;

    public class DeleteSlideCommandHandler : IRequestHandler<DeleteSlideCommandModel>
    {
        private readonly ISlidesRepository slidesRepository;
        private readonly IFileManager fileManager;

        public DeleteSlideCommandHandler(ISlidesRepository slidesRepository, IFileManager fileManager)
        {
            this.slidesRepository = slidesRepository;
            this.fileManager = fileManager;
        }

        public async Task<Unit> Handle(DeleteSlideCommandModel request, CancellationToken cancellationToken)
        {
            var slide = await slidesRepository.GetAndEnsureExistAsync(request.Id);
            await slidesRepository.DeleteAsync(slide);
            await slidesRepository.SaveChangesAsync();

            fileManager.RemoveFile(Path.Combine("wwwroot", slide.ImageUrl));
            return Unit.Value;
        }
    }
}