using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Dto.Products;
using Streetwood.Infrastructure.Queries.Models.Product;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Product
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryModel, ProductDto>
    {
        private readonly IProductQueryService productQueryService;

        public GetProductByIdQueryHandler(IProductQueryService productQueryService)
        {
            this.productQueryService = productQueryService;
        }

        public async Task<ProductDto> Handle(GetProductByIdQueryModel request, CancellationToken cancellationToken)
            => await productQueryService.GetAsync(request.Id);
    }
}
