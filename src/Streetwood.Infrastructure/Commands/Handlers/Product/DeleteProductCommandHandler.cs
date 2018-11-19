using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Commands.Models.Product;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Product
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandModel, Unit>
    {
        private readonly IProductCommandService productCommandService;
        private readonly ICache cache;

        public DeleteProductCommandHandler(IProductCommandService productCommandService, ICache cache)
        {
            this.productCommandService = productCommandService;
            this.cache = cache;
        }

        public async Task<Unit> Handle(DeleteProductCommandModel request, CancellationToken cancellationToken)
        {
            await productCommandService.DeleteAsync(request.Id);
            cache.Remove(CacheKey.ProductList);
            cache.Remove($"{CacheKey.ProductsByCategory}{request.CategoryId.ToString()}");

            return Unit.Value;
        }
    }
}
