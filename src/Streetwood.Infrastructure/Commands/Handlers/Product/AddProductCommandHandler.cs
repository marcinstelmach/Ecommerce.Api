using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Product;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Product
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandModel, Unit>
    {
        private readonly IProductCommandService productCommandService;

        public AddProductCommandHandler(IProductCommandService productCommandService)
        {
            this.productCommandService = productCommandService;
        }

        public async Task<Unit> Handle(AddProductCommandModel request, CancellationToken cancellationToken)
        {
            await productCommandService.AddAsync(request.Name, request.NameEng, request.Price, request.Description,
                request.DescriptionEng, request.AcceptCharms, request.Sizes, request.ProductCategoryId);
            return Unit.Value;
        }
    }
}
