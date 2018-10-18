using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class CharmQueryService : ICharmQueryService
    {
        private readonly ICharmCategoryRepository charmCategoryRepository;
        private readonly IMapper mapper;

        public CharmQueryService(ICharmCategoryRepository charmCategoryRepository, IMapper mapper)
        {
            this.charmCategoryRepository = charmCategoryRepository;
            this.mapper = mapper;
        }

        public async Task<IList<CharmDto>> GetByCategoryId(Guid id)
        {
            var category = await charmCategoryRepository.GetAndEnsureExistAsync(id);
            var charms = category.Charms.ToList();
            return mapper.Map<IList<CharmDto>>(charms);
        }
    }
}
