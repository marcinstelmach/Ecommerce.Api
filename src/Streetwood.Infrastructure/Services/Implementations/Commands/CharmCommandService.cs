using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class CharmCommandService : ICharmCommandService
    {
        private readonly ICharmCategoryRepository charmCategoryRepository;
        private readonly ICharmRepository charmRepository;

        public CharmCommandService(ICharmCategoryRepository charmCategoryRepository, ICharmRepository charmRepository)
        {
            this.charmCategoryRepository = charmCategoryRepository;
            this.charmRepository = charmRepository;
        }

        public async Task<Guid> AddAsync(string name, string nameEng, decimal price, Guid charmCategoryId)
        {
            var category = await charmCategoryRepository.GetAndEnsureExistAsync(charmCategoryId);
            var charm = new Charm(name, nameEng, null, price);
            category.AddCharm(charm);

            await charmCategoryRepository.SaveChangesAsync();
            return charm.Id;
        }

        public async Task AddPhotoAsync(Guid id, IFormFile file)
        {
            var charm = await charmRepository.GetAndEnsureExistAsync(id);
            charm.SetUrl("");
        }
    }
}
