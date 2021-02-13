namespace Streetwood.Infrastructure.Commands.Handlers.Slides
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Core.Exceptions;
    using Streetwood.Core.Extensions;
    using Streetwood.Infrastructure.Commands.Models.Slides;
    using Streetwood.Infrastructure.Managers.Abstract;

    public class AddSlideImageCommandHandler : IRequestHandler<AddSlideImageCommandModel>
    {
        private readonly ISlidesRepository slidesRepository;
        private readonly IPathManager pathManager;
        private readonly IFileManager fileManager;

        public AddSlideImageCommandHandler(ISlidesRepository slidesRepository, IPathManager pathManager, IFileManager fileManager)
        {
            this.slidesRepository = slidesRepository;
            this.pathManager = pathManager;
            this.fileManager = fileManager;
        }

        public async Task<Unit> Handle(AddSlideImageCommandModel request, CancellationToken cancellationToken)
        {
            var slide = await slidesRepository.GetAndEnsureExistAsync(request.Id);
            if (slide.ImageUrl != null)
            {
                throw new StreetwoodException(ErrorCode.SlideAlreadyHaveImage);
            }

            var imageUniqueName = request.File.FileName.GetUniqueFileName();
            var path = pathManager.GetSlideImagesPath();
            var pathToSave = Path.Combine("wwwroot", path);

            await fileManager.MoveFileAsync(request.File, pathToSave, imageUniqueName);
            slide.SetImageUrl(Path.Combine(path, imageUniqueName));

            await slidesRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}