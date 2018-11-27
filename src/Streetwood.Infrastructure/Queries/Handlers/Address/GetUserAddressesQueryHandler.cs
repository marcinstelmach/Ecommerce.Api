using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.Address;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Address
{
    public class GetUserAddressesQueryHandler : IRequestHandler<GetUserAddressesQueryModel, IList<AddressDto>>
    {
        private readonly IAddressQueryService addressQueryService;

        public GetUserAddressesQueryHandler(IAddressQueryService addressQueryService)
        {
            this.addressQueryService = addressQueryService;
        }

        public async Task<IList<AddressDto>> Handle(GetUserAddressesQueryModel request, CancellationToken cancellationToken)
            => await addressQueryService.GetByUserAsync(request.UserId);
    }
}
