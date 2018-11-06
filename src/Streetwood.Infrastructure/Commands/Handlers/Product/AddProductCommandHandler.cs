using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Commands.Models.Product;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Product
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandModel, int>
    {
        private readonly IProductCommandService productCommandService;
        private readonly IMemoryCache cache;

        public AddProductCommandHandler(IProductCommandService productCommandService, IMemoryCache cache)
        {
            this.productCommandService = productCommandService;
            this.cache = cache;
        }

        public async Task<int> Handle(AddProductCommandModel request, CancellationToken cancellationToken)
        {
            var productId = await productCommandService.AddAsync(request.Name, request.NameEng, request.Price, request.Description,
                request.DescriptionEng, request.AcceptCharms, request.Sizes, request.ProductCategoryId);
            cache.Remove(CacheKey.ProductList);

            return productId;
        }
    }
}
