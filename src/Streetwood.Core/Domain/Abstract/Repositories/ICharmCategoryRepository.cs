using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Abstract.Repositories
{
    public interface ICharmCategoryRepository : IRepository<CharmCategory>
    {
        Task AddAsync(CharmCategory charmCategory);

        Task<IList<CharmCategory>> GetWithCharmsAsync();

        Task<CharmCategory> GetWithCharmsAsync(Guid id);
    }
}
