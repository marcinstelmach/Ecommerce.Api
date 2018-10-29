using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers
{
    public class DeleteCharmCategoryCommandHandler : IRequestHandler<DeleteCharmCategoryCommandModel, Unit>
    {
        private readonly ICharmCategoryCommandService charmCategoryCommandService;

        public DeleteCharmCategoryCommandHandler(ICharmCategoryCommandService charmCategoryCommandService)
        {
            this.charmCategoryCommandService = charmCategoryCommandService;
        }

        public async Task<Unit> Handle(DeleteCharmCategoryCommandModel request, CancellationToken cancellationToken)
        {
            await charmCategoryCommandService.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
