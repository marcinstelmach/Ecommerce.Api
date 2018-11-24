using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Charm;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Charm
{
    public class UpdateCharmCommandHandler : IRequestHandler<UpdateCharmCommandModel, Unit>
    {
        private readonly ICharmCommandService charmCommandService;

        public UpdateCharmCommandHandler(ICharmCommandService charmCommandService)
        {
            this.charmCommandService = charmCommandService;
        }

        public async Task<Unit> Handle(UpdateCharmCommandModel request, CancellationToken cancellationToken)
        {
            await charmCommandService.UpdateAsync(request.Id, request.Name, request.NameEng, request.Price);
            return Unit.Value;
        }
    }
}
