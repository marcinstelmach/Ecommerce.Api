using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Commands.Models.ProductCategory;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.ProductCategory
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommandModel, Unit>
    {
        private readonly IProductCategoryCommandService service;
        private readonly IMemoryCache cache;

        public UpdateProductCategoryCommandHandler(IProductCategoryCommandService service, IMemoryCache cache)
        {
            this.service = service;
            this.cache = cache;
        }

        public async Task<Unit> Handle(UpdateProductCategoryCommandModel request, CancellationToken cancellationToken)
        {
            await service.UpdateAsync(request.Id, request.Name, request.NameEng);
            cache.Remove(CacheKey.ProductCategoryTree);

            return Unit.Value;
        }
    }
}
