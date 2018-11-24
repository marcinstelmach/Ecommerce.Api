using System;
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


        public async Task<CharmDto> GetAsync(Guid id)
        {
            var charm = await charmCategoryRepository.GetAndEnsureExistAsync(id);
            return mapper.Map<CharmDto>(charm);
        }
    }
}
