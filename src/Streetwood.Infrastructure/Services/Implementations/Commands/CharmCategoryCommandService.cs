using System;
using System.Linq;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class CharmCategoryCommandService : ICharmCategoryCommandService
    {
        private readonly ICharmCategoryRepository charmCategoryRepository;

        public CharmCategoryCommandService(ICharmCategoryRepository charmCategoryRepository)
        {
            this.charmCategoryRepository = charmCategoryRepository;
        }

        public async Task AddAsync(string name, string nameEng)
        {
            await charmCategoryRepository.AddAsync(new CharmCategory(name, nameEng));
            await charmCategoryRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, string name, string nameEng)
        {
            var category = await charmCategoryRepository.GetAndEnsureExistAsync(id);
            category.SetName(name);
            category.SetEngName(nameEng);

            await charmCategoryRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var charmCategory = await charmCategoryRepository.GetAndEnsureExistAsync(id);
            var charms = charmCategory.Charms.ToList();

            charms.ForEach(s => s.SetStatus(ItemStatus.Deleted));
            charmCategory.SetStatus(ItemStatus.Deleted);
            await charmCategoryRepository.SaveChangesAsync();
        }
    }
}
