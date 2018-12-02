using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.ProductCategoryDiscount;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.ProductCategoryDiscount
{
    public class AddProductCategoryToDiscountCommandHandler : IRequestHandler<AddProductCategoryToDiscountCommandModel, Unit>
    {
        private readonly IProductCategoryDiscountCommandService service;

        public AddProductCategoryToDiscountCommandHandler(IProductCategoryDiscountCommandService service)
        {
            this.service = service;
        }

        public async Task<Unit> Handle(AddProductCategoryToDiscountCommandModel request, CancellationToken cancellationToken)
        {
            await service.SetCategoriesAsync(request.DiscountId, request.CategoryIds);
            return Unit.Value;
        }
    }
}
