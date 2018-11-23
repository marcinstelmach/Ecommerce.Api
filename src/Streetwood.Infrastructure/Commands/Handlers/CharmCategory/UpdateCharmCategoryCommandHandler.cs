using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.CharmCategory;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.CharmCategory
{
    public class UpdateCharmCategoryCommandHandler : IRequestHandler<UpdateCharmCategoryCommandModel, Unit>
    {
        private readonly ICharmCategoryCommandService charmCategoryCommandService;

        public UpdateCharmCategoryCommandHandler(ICharmCategoryCommandService charmCategoryCommandService)
        {
            this.charmCategoryCommandService = charmCategoryCommandService;
        }

        public async Task<Unit> Handle(UpdateCharmCategoryCommandModel request, CancellationToken cancellationToken)
        {
            await charmCategoryCommandService.UpdateAsync(request.Id, request.Name, request.NameEng);
            return Unit.Value;
        }
    }
}
