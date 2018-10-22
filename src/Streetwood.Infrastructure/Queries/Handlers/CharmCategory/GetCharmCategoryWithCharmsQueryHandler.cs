using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.CharmCategory;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.CharmCategory
{
    public class GetCharmCategoryWithCharmsQueryHandler : IRequestHandler<GetCharmCategoryWithCharmsQueryModel, CharmCategoryDto>
    {
        private readonly ICharmCategoryQueryService charmCategoryQueryService;

        public GetCharmCategoryWithCharmsQueryHandler(ICharmCategoryQueryService charmCategoryQueryService)
        {
            this.charmCategoryQueryService = charmCategoryQueryService;
        }

        public async Task<CharmCategoryDto> Handle(GetCharmCategoryWithCharmsQueryModel request, CancellationToken cancellationToken)
            => await charmCategoryQueryService.GetAsync(request.Id);
    }
}
