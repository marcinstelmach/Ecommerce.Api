using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Services.Abstract.Commands.Address;

namespace Streetwood.Infrastructure.Commands.Handlers
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommandModel, Unit>
    {
        private readonly IAddressCommandService addressCommandService;

        public AddAddressCommandHandler(IAddressCommandService addressCommandService)
        {
            this.addressCommandService = addressCommandService;
        }

        public async Task<Unit> Handle(AddAddressCommandModel request, CancellationToken cancellationToken)
        {
            await addressCommandService.AddAsync(request.City, request.Street, request.PostCode, request.PhoneNumber, request.Country, request.UserId);
            return Unit.Value;
        }
    }
}
