using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Commands.Models.Product;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Product
{
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommandModel, Unit>
    {
        private readonly IImageCommandService imageCommandService;

        public DeleteImageCommandHandler(IImageCommandService imageCommandService)
        {
            this.imageCommandService = imageCommandService;
        }

        public async Task<Unit> Handle(DeleteImageCommandModel request, CancellationToken cancellationToken)
        {
            await imageCommandService.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
