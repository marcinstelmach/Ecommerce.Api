using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.ProductCategoryDiscount;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.ProductCategoryDiscount
{
    public class AddProductCategoryDiscountCommandHandler : IRequestHandler<AddProductCategoryDiscountCommandModel, Unit>
    {
        private readonly IProductCategoryDiscountCommandService service;

        public AddProductCategoryDiscountCommandHandler(IProductCategoryDiscountCommandService service)
        {
            this.service = service;
        }

        public async Task<Unit> Handle(AddProductCategoryDiscountCommandModel request, CancellationToken cancellationToken)
        {
            await service.AddAsync(request.Name, request.NameEng, request.Description, request.DescriptionEng,
                request.PercentValue, request.AvailableFrom.Date, request.AvailableTo.Date);
            return Unit.Value;
        }
    }
}
