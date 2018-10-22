using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface ICharmCategoryQueryService
    {
        Task<IList<CharmCategoryDto>> GetAsync();

        Task<CharmCategoryDto> GetAsync(Guid id);
    }
}
