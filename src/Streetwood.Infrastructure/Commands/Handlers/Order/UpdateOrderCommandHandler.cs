
namespace Streetwood.Infrastructure.Commands.Handlers.Order
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Core.Domain.Enums;
    using Streetwood.Infrastructure.Commands.Models.Order;
    using Streetwood.Infrastructure.Dto;
    using Streetwood.Infrastructure.Services.Abstract;

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandModel>
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IEmailService emailService;

        public UpdateOrderCommandHandler(IOrdersRepository ordersRepository, IEmailService emailService)
        {
            this.ordersRepository = ordersRepository;
            this.emailService = emailService;
        }

        public async Task<Unit> Handle(UpdateOrderCommandModel request, CancellationToken cancellationToken)
        {
            var order = await ordersRepository.GetAndEnsureExistAsync(request.Id);
            if (order.OrderShipment.Status != ShipmentStatus.InProgress && request.ShipmentStatus == ShipmentStatusDto.InProgress)
            {
                order.OrderShipment.Send();
                await emailService.SendOrderWasShippedEmailAsync(order);
            }

            if (order.OrderShipment.Status != ShipmentStatus.Completed && request.ShipmentStatus == ShipmentStatusDto.Completed)
            {
                order.OrderShipment.Complete();
            }

            if (order.OrderPayment.Status != PaymentStatus.Completed && request.PaymentStatus == PaymentStatusDto.Completed)
            {
                order.OrderPayment.Complete();
            }

            await ordersRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
