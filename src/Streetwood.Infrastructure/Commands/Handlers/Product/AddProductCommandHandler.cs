using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Product;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Product
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandModel, int>
    {
        private readonly IProductCommandService productCommandService;

        public AddProductCommandHandler(IProductCommandService productCommandService)
        {
            this.productCommandService = productCommandService;
        }

        public async Task<int> Handle(AddProductCommandModel request, CancellationToken cancellationToken)
        {
            var productId = await productCommandService.AddAsync(request.Name, request.NameEng, request.Price, request.Description,
                request.DescriptionEng, request.AcceptCharms, request.AcceptGraver, request.MaxCharmCount, request.Sizes, request.ProductCategoryId);

            return productId;
        }
    }
}
