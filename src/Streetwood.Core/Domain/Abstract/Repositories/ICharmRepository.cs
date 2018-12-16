using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Abstract.Repositories
{
    public interface ICharmRepository : IRepository<Charm>
    {
        Task<IList<Charm>> GetByIdsAsync(IEnumerable<Guid> ids);
    }
}
