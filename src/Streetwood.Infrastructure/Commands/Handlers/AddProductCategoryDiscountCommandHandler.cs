using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers
{
    public class AddProductCategoryDiscountCommandHandler : IRequestHandler<AddProductCategoryDiscountCommandModel, Unit>
    {
        private readonly IProductCategoryDiscountCommandService service;
        private readonly IMemoryCache cache;

        public AddProductCategoryDiscountCommandHandler(IProductCategoryDiscountCommandService service, IMemoryCache cache)
        {
            this.service = service;
            this.cache = cache;
        }

        public async Task<Unit> Handle(AddProductCategoryDiscountCommandModel request, CancellationToken cancellationToken)
        {
            await service.AddAsync(request.Name, request.NameEng, request.Description, request.DescriptionEng,
                request.PercentValue, request.AvailableFrom, request.AvailableTo);

            cache.Remove(CacheKey.ProductCategoryDiscountList);

            return Unit.Value;
        }
    }
}
