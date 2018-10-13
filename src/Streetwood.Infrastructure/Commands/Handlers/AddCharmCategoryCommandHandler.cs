using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.CharmCategory;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers
{
    public class AddCharmCategoryCommandHandler : IRequestHandler<AddCharmCategoryCommandModel, Unit>
    {
        private readonly ICharmCategoryCommandService charmCategoryCommandService;

        public AddCharmCategoryCommandHandler(ICharmCategoryCommandService charmCategoryCommandService)
        {
            this.charmCategoryCommandService = charmCategoryCommandService;
        }

        public async Task<Unit> Handle(AddCharmCategoryCommandModel request, CancellationToken cancellationToken)
        {
            await charmCategoryCommandService.AddAsync(request.Name);
            return Unit.Value;
        }
    }
}
