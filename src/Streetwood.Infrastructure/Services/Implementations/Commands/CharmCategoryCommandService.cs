using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    public class CharmCategoryCommandService : ICharmCategoryCommandService
    {
        private readonly ICharmCategoryRepository charmCategoryRepository;

        public CharmCategoryCommandService(ICharmCategoryRepository charmCategoryRepository)
        {
            this.charmCategoryRepository = charmCategoryRepository;
        }

        public async Task AddAsync(string name)
        {
            await charmCategoryRepository.AddAsync(new CharmCategory(name));
            await charmCategoryRepository.SaveChangesAsync();
        }
    }
}
