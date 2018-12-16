using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface ICharmQueryService
    {
        Task<CharmDto> GetAsync(Guid id);

        Task<IList<CharmDto>> GetByIdsAsync(IList<Guid> ids);
    }
}
