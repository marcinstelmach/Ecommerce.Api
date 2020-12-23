using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Product;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.Product
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandModel, Unit>
    {
        private readonly IProductCommandService productCommandService;

        public UpdateProductCommandHandler(IProductCommandService productCommandService)
        {
            this.productCommandService = productCommandService;
        }

        public async Task<Unit> Handle(UpdateProductCommandModel request, CancellationToken cancellationToken)
        {
            await productCommandService.UpdateAsync(request.Id, request.Name, request.NameEng, request.Price,
                request.Description, request.DescriptionEng, request.AcceptCharms, request.AcceptGraver, request.Sizes, request.ProductColors);

            return Unit.Value;
        }
    }
}
