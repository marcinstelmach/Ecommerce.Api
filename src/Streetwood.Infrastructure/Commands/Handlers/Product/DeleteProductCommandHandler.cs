using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Product;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Product
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandModel, Unit>
    {
        private readonly IProductCommandService productCommandService;

        public DeleteProductCommandHandler(IProductCommandService productCommandService)
        {
            this.productCommandService = productCommandService;
        }

        public async Task<Unit> Handle(DeleteProductCommandModel request, CancellationToken cancellationToken)
        {
            await productCommandService.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
