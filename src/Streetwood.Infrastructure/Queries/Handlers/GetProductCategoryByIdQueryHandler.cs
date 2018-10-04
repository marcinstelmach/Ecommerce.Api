using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.ProductCategory;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers
{
    public class GetProductCategoryByIdQueryHandler : IRequestHandler<GetProductCategoryByIdQueryModel, ProductCategoryDto>
    {
        private readonly IProductCategoryQueryService productCategoryQueryService;

        public GetProductCategoryByIdQueryHandler(IProductCategoryQueryService productCategoryQueryService)
        {
            this.productCategoryQueryService = productCategoryQueryService;
        }

        public async Task<ProductCategoryDto> Handle(GetProductCategoryByIdQueryModel request, CancellationToken cancellationToken)
        {
            return await productCategoryQueryService.GetProductCategoryByIdAsync(request.Id);
        }
    }
}
