using System;
using System.Linq;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    public class CharmCategoryCommandService : ICharmCategoryCommandService
    {
        private readonly ICharmCategoryRepository charmCategoryRepository;
        private readonly IFileManager fileManager;

        public CharmCategoryCommandService(ICharmCategoryRepository charmCategoryRepository, IFileManager fileManager)
        {
            this.charmCategoryRepository = charmCategoryRepository;
            this.fileManager = fileManager;
        }

        public async Task AddAsync(string name)
        {
            await charmCategoryRepository.AddAsync(new CharmCategory(name));
            await charmCategoryRepository.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var charmCategory = await charmCategoryRepository.GetAndEnsureExistAsync(id);
            var charms = charmCategory.Charms.ToList();

            await charmCategoryRepository.DeleteAsync(charmCategory);
            await charmCategoryRepository.SaveChangesAsync();

            charms.ForEach(s => fileManager.RemoveFile(s.ImageUrl));
        }
    }
}
