using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.CodeDiscount;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.OrderDiscount
{
    public class AddOrderDiscountCommandHandler : IRequestHandler<AddOrderDiscountCommandModel, Unit>
    {
        private readonly IOrderDiscountCommandService orderDiscountCommandService;

        public AddOrderDiscountCommandHandler(IOrderDiscountCommandService orderDiscountCommandService)
        {
            this.orderDiscountCommandService = orderDiscountCommandService;
        }

        public async Task<Unit> Handle(AddOrderDiscountCommandModel request, CancellationToken cancellationToken)
        {
            await orderDiscountCommandService.AddAsync(request.Name, request.NameEng, request.Description,
                request.DescriptionEng, request.PercentValue, request.AvailableFrom, request.AvailableTo, request.Code);

            return Unit.Value;
        }
    }
}
