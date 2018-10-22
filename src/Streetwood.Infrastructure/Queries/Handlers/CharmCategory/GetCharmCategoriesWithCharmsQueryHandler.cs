using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.CharmCategory;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.CharmCategory
{
    public class GetCharmCategoriesWithCharmsQueryHandler : IRequestHandler<GetCharmCategoriesWithCharmsQueryModel, IList<CharmCategoryDto>>
    {
        private readonly ICharmCategoryQueryService charmCategoryQueryService;

        public GetCharmCategoriesWithCharmsQueryHandler(ICharmCategoryQueryService charmCategoryQueryService)
        {
            this.charmCategoryQueryService = charmCategoryQueryService;
        }

        public async Task<IList<CharmCategoryDto>> Handle(GetCharmCategoriesWithCharmsQueryModel request, CancellationToken cancellationToken)
            => await charmCategoryQueryService.GetAsync();
    }
}
