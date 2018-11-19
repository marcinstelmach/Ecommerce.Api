using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Commands.Models.ProductCategory;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.ProductCategory
{
    public class AddProductCategoriesCommandHandler : IRequestHandler<AddProductCategoryCommandModel, Unit>
    {
        private readonly IProductCategoryCommandService productCategoryCommandService;
        private readonly ICache cache;

        public AddProductCategoriesCommandHandler(IProductCategoryCommandService productCategoryCommandService, ICache cache)
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
