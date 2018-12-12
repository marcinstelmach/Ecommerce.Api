using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.OrderDiscount;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers.OrderDiscount
{
    public class UpdateOrderDiscountCommandHandler : IRequestHandler<UpdateOrderDiscountCommandModel, Unit>
    {
        private readonly IOrderDiscountCommandService orderDiscountCommandService;

        public UpdateOrderDiscountCommandHandler(IOrderDiscountCommandService orderDiscountCommandService)
        {
            this.orderDiscountCommandService = orderDiscountCommandService;
        }

        public async Task<Unit> Handle(UpdateOrderDiscountCommandModel request, CancellationToken cancellationToken)
        {
            await orderDiscountCommandService.UpdateAsync(request.Id, request.Name, request.NameEng,
                request.Description, request.DescriptionEng, request.PercentValue, request.AvailableFrom,
                request.AvailableTo, request.Code);

            return Unit.Value;
        }
    }
}
