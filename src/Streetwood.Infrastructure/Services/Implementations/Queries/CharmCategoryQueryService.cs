using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class CharmCategoryQueryService : ICharmCategoryQueryService
    {
        private readonly ICharmCategoryRepository charmCategoryRepository;
        private readonly IMapper mapper;

        public CharmCategoryQueryService(ICharmCategoryRepository charmCategoryRepository, IMapper mapper)
        {
            this.charmCategoryRepository = charmCategoryRepository;
            this.mapper = mapper;
        }

        public async Task<IList<CharmCategoryDto>> GetAsync()
        {
            var categories = await charmCategoryRepository.GetWithCharmsAsync();
            return mapper.Map<IList<CharmCategoryDto>>(categories);
        }

        public async Task<CharmCategoryDto> GetAsync(Guid id)
        {
            var category = await charmCategoryRepository.GetWithCharmsAsync(id);
            return mapper.Map<CharmCategoryDto>(category);
        }
    }
}
