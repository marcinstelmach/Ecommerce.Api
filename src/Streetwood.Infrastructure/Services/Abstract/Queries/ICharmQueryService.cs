using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface ICharmQueryService
    {
        Task<CharmDto> GetAsync(Guid id);

        Task<IList<Charm>> GetRawByIdsAsync(IList<Guid> ids);
    }
}
