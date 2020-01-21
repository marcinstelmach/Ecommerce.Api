using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Product;
using Streetwood.Infrastructure.Dto.Products;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Product
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandModel, int>
    {
        private readonly IProductCommandService productCommandService;
        private readonly IMapper mapper;

        public AddProductCommandHandler(IProductCommandService productCommandService, IMapper mapper)
        {
            this.productCommandService = productCommandService;
            this.mapper = mapper;
        }

        public async Task<int> Handle(AddProductCommandModel request, CancellationToken cancellationToken)
        {
            var dto = mapper.Map<AddProductDto>(request);
            var productId = await productCommandService.AddAsync(dto);

            return productId;
        }
    }
}
