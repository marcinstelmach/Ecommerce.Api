using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.Charm;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.Charm
{
    public class GetCharmsByCategoryIdQueryHandler : IRequestHandler<GetCharmByIdQueryModel, CharmDto>
    {
        private readonly ICharmQueryService charmQueryService;

        public GetCharmsByCategoryIdQueryHandler(ICharmQueryService charmQueryService)
        {
            this.charmQueryService = charmQueryService;
        }

        public async Task<CharmDto> Handle(GetCharmByIdQueryModel request, CancellationToken cancellationToken)
            => await charmQueryService.GetAsync(request.Id);
    }
}
