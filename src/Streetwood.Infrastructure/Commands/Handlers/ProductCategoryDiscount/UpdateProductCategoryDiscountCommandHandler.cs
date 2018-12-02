using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.ProductCategoryDiscount;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.ProductCategoryDiscount
{
    public class UpdateProductCategoryDiscountCommandHandler : IRequestHandler<UpdateProductCategoryDiscountCommandModel, Unit>
    {
        private readonly IProductCategoryDiscountCommandService service;

        public UpdateProductCategoryDiscountCommandHandler(IProductCategoryDiscountCommandService service)
        {
            this.service = service;
        }

        public async Task<Unit> Handle(UpdateProductCategoryDiscountCommandModel request, CancellationToken cancellationToken)
        {
            await service.UpdateAsync(request.Id, request.Name, request.NameEng, request.Description,
                request.DescriptionEng, request.PercentValue, request.AvailableFrom.Date, request.AvailableTo.Date);

            return Unit.Value;
        }
    }
}
