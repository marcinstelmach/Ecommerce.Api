using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Charm;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Charm
{
    public class DeleteCharmCommandHandler : IRequestHandler<DeleteCharmCommandModel, Unit>
    {
        private readonly ICharmCommandService charmCommandService;

        public DeleteCharmCommandHandler(ICharmCommandService charmCommandService)
        {
            this.charmCommandService = charmCommandService;
        }

        public async Task<Unit> Handle(DeleteCharmCommandModel request, CancellationToken cancellationToken)
        {
            await charmCommandService.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
