using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.ProductCategory;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.ProductCategory
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommandModel, Unit>
    {
        private readonly IProductCategoryCommandService productCategoryCommandService;

        public DeleteProductCategoryCommandHandler(IProductCategoryCommandService productCategoryCommandService)
        {
            this.productCategoryCommandService = productCategoryCommandService;
        }

        public async Task<Unit> Handle(DeleteProductCategoryCommandModel request, CancellationToken cancellationToken)
        {
            await productCategoryCommandService.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
