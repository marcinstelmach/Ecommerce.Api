using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.ProductCategory;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.ProductCategory
{
    public class AddProductCategoriesCommandHandler : IRequestHandler<AddProductCategoryCommandModel, Unit>
    {
        private readonly IProductCategoryCommandService productCategoryCommandService;

        public AddProductCategoriesCommandHandler(IProductCategoryCommandService productCategoryCommandService)
        {
            this.productCategoryCommandService = productCategoryCommandService;
        }

        public async Task<Unit> Handle(AddProductCategoryCommandModel request, CancellationToken cancellationToken)
        {
            await productCategoryCommandService.AddAsync(request.Name, request.NameEng, request.ProductCategoryId);
            return Unit.Value;
        }
    }
}
