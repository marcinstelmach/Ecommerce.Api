using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Commands.Handlers
{
    public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommandModel, Unit>
    {
        private readonly IShipmentCommandService service;

        public DeleteShipmentCommandHandler(IShipmentCommandService service)
        {
            this.service = service;
        }

        public async Task<Unit> Handle(DeleteShipmentCommandModel request, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
