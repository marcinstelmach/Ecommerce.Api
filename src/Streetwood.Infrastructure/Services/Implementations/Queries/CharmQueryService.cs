using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Internal;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class CharmQueryService : ICharmQueryService
    {
        private readonly ICharmCategoryRepository charmCategoryRepository;
        private readonly ICharmRepository charmRepository;
        private readonly IMapper mapper;

        public CharmQueryService(ICharmCategoryRepository charmCategoryRepository, ICharmRepository charmRepository, IMapper mapper)
        {
            this.charmCategoryRepository = charmCategoryRepository;
            this.charmRepository = charmRepository;
            this.mapper = mapper;
        }

        public async Task<CharmDto> GetAsync(Guid id)
        {
            var charm = await charmCategoryRepository.GetAndEnsureExistAsync(id);
            return mapper.Map<CharmDto>(charm);
        }

        public async Task<IList<Charm>> GetRawByIdsAsync(IList<Guid> ids)
        {
            if (!ids.Any())
            {
                return null;
            }

            var charms = await charmRepository.GetByIdsAsync(ids);

            if (!charms.Any())
            {
                throw new StreetwoodException(ErrorCode.OrderCharmsNotFound);
            }

            return charms;
        }
    }
}
