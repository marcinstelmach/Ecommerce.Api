using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Commands.Models.ProductCategory;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.ProductCategory
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommandModel, Unit>
    {
        private readonly IProductCategoryCommandService productCategoryCommandService;
        private readonly ICache cache;

        public DeleteProductCategoryCommandHandler(IProductCategoryCommandService productCategoryCommandService, ICache cache)
        {
            this.productCategoryCommandService = productCategoryCommandService;
            this.cache = cache;
        }

        public async Task<Unit> Handle(DeleteProductCategoryCommandModel request, CancellationToken cancellationToken)
        {
            await productCategoryCommandService.DeleteAsync(request.Id);
            cache.Remove(CacheKey.ProductCategoryTree);

            return Unit.Value;
        }
    }
}
