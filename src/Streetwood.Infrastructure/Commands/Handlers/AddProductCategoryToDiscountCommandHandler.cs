using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers
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
            await service.Update(request.CategoryId, request.DiscountId);
            return Unit.Value;
        }
    }
}
