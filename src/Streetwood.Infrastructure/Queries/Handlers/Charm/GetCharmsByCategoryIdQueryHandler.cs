using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.Charm;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Charm
{
    public class GetCharmsByCategoryIdQueryHandler : IRequestHandler<GetCharmsByCategoryIdQueryModel, IList<CharmDto>>
    {
        private readonly ICharmQueryService charmQueryService;

        public GetCharmsByCategoryIdQueryHandler(ICharmQueryService charmQueryService)
        {
            this.charmQueryService = charmQueryService;
        }

        public async Task<IList<CharmDto>> Handle(GetCharmsByCategoryIdQueryModel request, CancellationToken cancellationToken)
            => await charmQueryService.GetByCategoryId(request.Id);
    }
}
