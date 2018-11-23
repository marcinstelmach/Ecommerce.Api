using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class CharmCommandService : ICharmCommandService
    {
        private readonly ICharmCategoryRepository charmCategoryRepository;
        private readonly ICharmRepository charmRepository;
        private readonly IPathManager pathManager;
        private readonly IFileManager fileManager;

        public CharmCommandService(ICharmCategoryRepository charmCategoryRepository,
            ICharmRepository charmRepository,
            IPathManager pathManager,
            IFileManager fileManager)
        {
            this.charmCategoryRepository = charmCategoryRepository;
            this.charmRepository = charmRepository;
            this.pathManager = pathManager;
            this.fileManager = fileManager;
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
            var imageUniqueName = file.FileName.GetUniqueFileName();
            var path = pathManager.GetCharmImagePath(charm.CharmCategory.UniqueName);
            var pathToSave = Path.Combine("wwwroot", path);

            await fileManager.MoveFileAsync(file, pathToSave, imageUniqueName);
            charm.SetUrl(Path.Combine(path, imageUniqueName));

            await charmRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var charm = await charmRepository.GetAndEnsureExistAsync(id);
            charm.SetStatus(ItemStatus.Deleted);

            await charmRepository.SaveChangesAsync();
        }
    }
}
