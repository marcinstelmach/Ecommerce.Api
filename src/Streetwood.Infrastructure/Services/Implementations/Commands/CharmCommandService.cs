using System;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class CharmCommandService : ICharmCommandService
    {
        private readonly ICharmCategoryRepository charmCategoryRepository;

        public CharmCommandService(ICharmCategoryRepository charmCategoryRepository)
        {
            this.charmCategoryRepository = charmCategoryRepository;
        }

        public async Task AddAsync(string name, string nameEng, decimal price, Guid charmCategoryId)
        {
            var category = await charmCategoryRepository.GetAndEnsureExist(charmCategoryId);
            category.AddCharm(new Charm(name, nameEng, null, price));

            await charmCategoryRepository.SaveChangesAsync();
        }
    }
}
