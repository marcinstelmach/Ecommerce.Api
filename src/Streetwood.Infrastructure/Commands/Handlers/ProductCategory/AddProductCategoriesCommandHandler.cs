using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Commands.Models.ProductCategory;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.ProductCategory
{
    public class AddProductCategoriesCommandHandler : IRequestHandler<AddProductCategoryCommandModel, Unit>
    {
        private readonly IProductCategoryCommandService productCategoryCommandService;
        private readonly IMemoryCache cache;

        public AddProductCategoriesCommandHandler(IProductCategoryCommandService productCategoryCommandService, IMemoryCache cache)
        {
            this.productCategoryCommandService = productCategoryCommandService;
            this.cache = cache;
        }

        public async Task<Unit> Handle(AddProductCategoryCommandModel request, CancellationToken cancellationToken)
        {
            await productCategoryCommandService.AddAsync(request.Name, request.NameEng, request.ProductCategoryId);
            cache.Remove(CacheKey.ProductCategoryTree);
            return Unit.Value;
        }
    }
}
