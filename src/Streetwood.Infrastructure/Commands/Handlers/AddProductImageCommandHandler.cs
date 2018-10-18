using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers
{
    public class AddProductImageCommandHandler : IRequestHandler<AddProductImageCommandModel, Unit>
    {
        private readonly IImageCommandService imageCommandService;

        public AddProductImageCommandHandler(IImageCommandService imageCommandService)
        {
            this.imageCommandService = imageCommandService;
        }

        public async Task<Unit> Handle(AddProductImageCommandModel request, CancellationToken cancellationToken)
        {
            await imageCommandService.AddAsync(request.File, request.ProductId, request.IsMain);
            return Unit.Value;
        }
    }
}
